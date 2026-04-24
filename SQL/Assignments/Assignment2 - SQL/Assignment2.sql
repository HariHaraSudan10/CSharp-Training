CREATE DATABASE sql_assignment2;

USE sql_assignment2;

--creating department table
create table Dept (deptno int primary key,    
				   dname  varchar(20),    
				   loc    varchar(20));

--creating employee table
create table Emp(empno int primary key,    
			 ename varchar(20),    
			 job varchar(20),    
			 [mgr-id] int,    
			 hiredate date,    
			 sal int,    
			 [comm.] int,    
			 deptno int,
			 foreign key (deptno) references Dept(deptno));

--inserting data into department table
insert into Dept 
	(deptno, dname, loc) 
	values
	(10, 'Accounting', 'New York'),
	(20, 'Research',   'Dallas'),
	(30, 'Sales',      'Chicago'),
	(40, 'Operations', 'Boston');

--inserting data into employee table
insert into Emp 
	(empno, ename, job, [mgr-id], hiredate, sal, [comm.], deptno) 
	values
	(7369, 'Smith',  'Clerk',     7902, convert(date,'17-12-1980',105),  800,  null, 20),
	(7499, 'Allen',  'Salesman',  7698, convert(date,'20-02-1981',105), 1600,  300,  30),
	(7521, 'Ward',   'Salesman',  7698, convert(date,'22-02-1981',105), 1250,  500,  30),
	(7566, 'Jones',  'Manager',   7839, convert(date,'02-04-1981',105), 2975,  null, 20),
	(7654, 'Martin', 'Salesman',  7698, convert(date,'28-09-1981',105), 1250, 1400,  30),
	(7698, 'Blake',  'Manager',   7839, convert(date,'01-05-1981',105), 2850,  null, 30),
	(7782, 'Clark',  'Manager',   7839, convert(date,'09-06-1981',105), 2450,  null, 10),
	(7788, 'Scott',  'Analyst',   7566, convert(date,'19-04-1987',105), 3000,  null, 20),
	(7839, 'King',   'President', null, convert(date,'17-11-1981',105), 5000,  null, 10),
	(7844, 'Turner', 'Salesman',  7698, convert(date,'08-09-1981',105), 1500,    0,  30),
	(7876, 'Adams',  'Clerk',     7788, convert(date,'23-05-1987',105), 1100,  null, 20),
	(7900, 'James',  'Clerk',     7698, convert(date,'03-12-1981',105),  950,  null, 30),
	(7902, 'Ford',   'Analyst',   7566, convert(date,'03-12-1981',105), 3000,  null, 20),
	(7934, 'Miller', 'Clerk',     7782, convert(date,'23-01-1982',105), 1300,  null, 10);

--1. List all employees whose name begins with 'A'. 
---------------------------------------------------
SELECT * FROM Emp WHERE ename LIKE 'A%';

--2. Select all those employees who don't have a manager. 
---------------------------------------------------------
SELECT * FROM Emp WHERE [mgr-id] IS NULL;

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
--------------------------------------------------------------------------------------------------
SELECT ename Name, empno, sal Salary FROM Emp WHERE sal BETWEEN 1200 AND 1400;

--4. Give all the employees in the RESEARCH department a 10% pay rise. 
--Verify that this has been done by listing all their details before and after the rise. 
------------------------------------------------------------------------------------------
--before
SELECT * FROM Emp e join Dept d ON e.deptno = d.deptno WHERE dname = 'research';

--rise
UPDATE Emp SET sal = sal*1.10 WHERE deptno = (SELECT deptno FROM Dept WHERE dname = 'research');

--after
SELECT * FROM Emp e join Dept d ON e.deptno = d.deptno WHERE dname = 'research';

--5. Find the number of CLERKS employed. Give it a descriptive heading.
-----------------------------------------------------------------------
SELECT COUNT(*) AS 'Clerk Count' FROM Emp WHERE job = 'clerk';

--6. Find the average salary for each job type and the number of people employed in each job.
---------------------------------------------------------------------------------------------
SELECT job, COUNT(*) AS 'Count of Employee', AVG(sal) AS 'Average Salary' FROM Emp GROUP BY job;

--7. List the employees with the lowest and highest salary. 
SELECT * FROM Emp WHERE sal = (SELECT MIN(sal) FROM Emp)
UNION ALL
SELECT * FROM Emp WHERE sal = (SELECT MAX(sal) FROM Emp);

--8. List full details of departments that don't have any employees. 
--------------------------------------------------------------------
SELECT * FROM Dept d LEFT JOIN Emp e ON d.deptno = e.deptno WHERE e.empno IS NULL;

--9. Get the names and salaries of all the analysts earning more than 1200 
--who are based in department 20. Sort the answer by ascending order of name. 
------------------------------------------------------------------------------
SELECT ename AS Name, sal AS Salary 
FROM Emp 
WHERE job = 'analyst' AND sal > 1200 AND deptno = 20 
ORDER BY Name;

--10. For each department, 
--list its name and number together with the total salary paid to employees in that department. 
-------------------------------------------------------------------------------------------------
SELECT d.dname AS Department_Name, 
	   d.deptno AS Department_No, 
	   SUM(sal) AS Total_Salary_Given 
FROM 
	Dept d 
	JOIN 
	Emp e 
	ON 
	d.deptno = e.deptno 
	GROUP BY
	d.dname, d.deptno;

--11. Find out salary of both MILLER and SMITH.
-----------------------------------------------
SELECT All ename as Name, sal AS Salary FROM Emp WHERE ename IN ('miller','smith');

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
---------------------------------------------------------------------------
SELECT ename AS Name FROM Emp WHERE ename LIKE 'A%' OR ename LIKE 'M%'; 

--13. Compute yearly salary of SMITH. 
-------------------------------------
SELECT ename AS Name, (sal*12) AS YearlySalary FROM Emp WHERE ename = 'smith';

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
---------------------------------------------------------------------------------------------------
SELECT ename AS Name, sal AS Salary FROM Emp WHERE sal NOT BETWEEN 1500 AND 2850;

--15. Find all managers who have more than 2 employees reporting to them
------------------------------------------------------------------------
SELECT m.ename AS ManagerName 
FROM Emp m JOIN Emp e ON e.[mgr-id] = m.empno 
GROUP BY m.ename HAVING COUNT(e.empno) > 2;
