use sql_assignment2

SELECT * FROM Dept
SELECT * FROM Emp

--1. Retrieve a list of MANAGERS. 
SELECT * FROM Emp WHERE job = 'manager';

--2. Find out the names and salaries of all employees earning more than 1000 per month. 
SELECT ename Name, sal Salary FROM Emp WHERE sal > 1000;

--3. Display the names and salaries of all employees except JAMES. 
SELECT ename Name, sal Salary FROM Emp WHERE ename <> 'JAMES';

--4. Find out the details of employees whose names begin with ‘S’. 
SELECT * FROM Emp WHERE ename LIKE 'S%';

--5. Find out the names of all employees that have ‘A’ anywhere in their name.
SELECT ename Name FROM Emp WHERE ename LIKE '%A%';

--6. Find out the names of all employees that have ‘L’ as their third character in their name. 
SELECT ename Name FROM Emp WHERE ename LIKE '__L%';

--7. Compute daily salary of JONES. 
SELECT ename Name, sal/30 dailySalary FROM Emp WHERE ename = 'jones';

--8. Calculate the total monthly salary of all employees. 
SELECT SUM(sal) TotalMonthlySal FROM Emp;

--9. Print the average annual salary . 
SELECT AVG(sal*12) AvgAnnualSal FROM Emp; 

--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 
SELECT 
	ename Name, job Job, sal Salary, deptno DepartmentNo 
FROM Emp 
WHERE deptno = 30 AND job <> 'salesman';

--11. List unique departments of the EMP table. 
SELECT DISTINCT deptno FROM Emp 

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. 
--Label the columns Employee and Monthly Salary respectively.
SELECT ename Employee, sal 'Monthly Salary' FROM Emp WHERE sal > 1500 AND deptno IN (10,30);

--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 
SELECT ename Name, job Job, sal Salary 
FROM Emp
WHERE job IN ('manager', 'analyst') AND sal NOT IN (1000,3000,5000);

--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
SELECT ename Name, sal Salary, [comm.] Commission FROM Emp WHERE [comm.] > sal*1.10;

--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
SELECT ename Name FROM Emp WHERE ename LIKE '%L%L%' AND (deptno = 30 OR [mgr-id] = 7782);

--16. Display the names of employees with experience of over 30 years and under 40 yrs.
 --Count the total number of employees. 
 SELECT ename,(SELECT COUNT(*) FROM Emp) Name FROM Emp 
 WHERE DATEDIFF(YEAR, hiredate,GETDATE()) > 30 
	AND DATEDIFF(YEAR, hiredate, GETDATE()) <40;

--17. Retrieve the names of departments in ascending order and their employees in descending order. 
SELECT d.dname Departments, e.ename Employee FROM Dept d JOIN Emp e ON d.deptno = e.deptno 
ORDER BY d.dname , e.ename DESC;

--18. Find out experience of MILLER. 
SELECT ename Name, DATEDIFF(YEAR, hiredate, GETDATE()) Experience FROM Emp WHERE ename = 'MILLER'; 

