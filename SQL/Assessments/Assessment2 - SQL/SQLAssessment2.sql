USE sql_assignment2;

SELECT * FROM Emp;

--1.Write a query to display your birthday( day of week)
SELECT CAST('2005-01-14' AS DATE) AS Birthday, DATENAME(WEEKDAY, '2005-01-14') AS Day;

--2.Write a query to display your age in days
SELECT DATEDIFF(DAY, '2005-01-14', GETDATE()) AS AgeInDays;

--3.Write a query to display all employees information those who joined before 5 years in the current month
SELECT ename AS Name, hiredate AS JoinedDate FROM Emp WHERE DATEDIFF(YEAR, hiredate, GETDATE()) > 5
AND MONTH(hiredate) = MONTH(GETDATE());


--creating table employee

CREATE TABLE Employee
(
	empno INT,
	ename VARCHAR(20),
	sal DECIMAL(10,2),
	doj DATE
);



SELECT * FROM Employee;


--4.Create table Employee with empno, ename, sal, doj columns or 
--use your emp table and perform the following operations in a single transaction
--	a. First insert 3 rows 
--	b. Update the second row sal with 15% increment  
--  c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.

BEGIN TRANSACTION

--	a. First insert 3 rows 
INSERT INTO Employee(empno, ename, sal, doj)
VALUES(10, 'Messi', 1000000, '2000-01-10'),
	  (7, 'Ronaldo', 100000, '2000-07-01'),
	  (11, 'Neymar Jr', 10000, '2000-11-11');

BEGIN TRANSACTION

--	b. Update the second row sal with 15% increment  

UPDATE Employee 
SET sal = sal + (sal*0.15)
WHERE empno = 7;
SELECT * FROM Employee;


SAVE TRANSACTION BeforeDelete
--  c. Delete first row.
DELETE FROM Employee 
WHERE empno = 10;
SELECT * FROM Employee;


ROLLBACK TRANSACTION BeforeDelete;
SELECT * FROM Employee;


COMMIT TRANSACTION;
SELECT * FROM Employee;


--5.Create a user defined function calculate Bonus for all employees of a given dept 
--using following conditions
--	a.For Deptno 10 employees 15% of sal as bonus.
--	b.For Deptno 20 employees  20% of sal as bonus
--	c.For Others employees 5%of sal as bonus

CREATE FUNCTION fn_CalculateBonus
(@deptno INT, @sal DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @bonus DECIMAL(10,2)

	IF @deptno = 10
		SET @bonus = @sal*0.15

	IF @deptno = 20
		SET @bonus = @sal*0.20

	ELSE
		SET @bonus = @sal*0.05

	RETURN @bonus

END;

SELECT empno AS Id, ename AS Name, deptno AS DeptNo, sal AS Salary, 
dbo.fn_CalculateBonus(deptno, sal) AS Bonus 
FROM Emp;


--6. Create a procedure to update the salary of employee by 500 
--whose dept name is Sales and current salary is below 1500 (use emp table)

SELECT * FROM dept;
SELECT * FROM Emp;
CREATE PROCEDURE sp_UpdateSalesSal
AS
BEGIN
	UPDATE Emp
	SET sal = sal + 500
	WHERE deptno = (SELECT deptno FROM dept WHERE dname = 'Sales') AND sal < 1500

END;

EXEC sp_UpdateSalesSal;

UPDATE Emp 
SET sal = 1600 WHERE ename = 'Allen';

SELECT e.ename AS Name, d.dname AS DeptName, e.sal AS Salary 
FROM Emp e JOIN dept d ON e.deptno = d.deptno WHERE dname = 'Sales'; 