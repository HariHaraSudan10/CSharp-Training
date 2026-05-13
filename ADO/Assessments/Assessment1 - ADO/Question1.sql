--1. Create a database called Employeemanagement
CREATE DATABASE Employeemanagement;

USE Employeemanagement;

--creating table Employee_Details
CREATE TABLE Employee_Details
(
	Empno INT PRIMARY KEY,
	EmpName VARCHAR(50) NOT NULL,
	Empsal NUMERIC(10,2) CHECK(Empsal >= 25000),
	Emptype CHAR(1) CHECK(Emptype IN ('F', 'P'))
);

--creating stored procedure to add employees
CREATE PROCEDURE sp_AddEmployee
(
	@empname VARCHAR(50),
	@empsal NUMERIC(10,2),
	@emptype CHAR(1)
)
AS
BEGIN
	DECLARE @empno INT
	SELECT @empno = COALESCE(MAX(Empno), 0) + 1
	FROM Employee_Details;

	INSERT INTO Employee_Details(Empno, EmpName, Empsal, Emptype)
	VALUES(@empno, @empname, @empsal, @emptype);

END;

--checking the procedure
EXEC sp_AddEmployee 'Messi', 100000, 'F';
EXEC sp_AddEmployee 'Ronaldo', 70000, 'P';

SELECT * FROM Employee_Details;




