use sql_assignment2

SELECT * FROM Emp;

--1. Write a T-Sql based procedure to generate complete payslip of a given employee 
--with respect to the following condition

--a) HRA as 10% of Salary
--b) DA as 20% of Salary
--c) PF as 8% of Salary
--d) IT as 5% of Salary
--e) Deductions as sum of PF and IT
--f) Gross Salary as sum of Salary, HRA, DA
--g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details

CREATE OR ALTER PROCEDURE sp_generatepayslip
    @EmpID INT
AS
BEGIN
    DECLARE @ename VARCHAR(100),
            @sal DECIMAL(10,2),
            @hra DECIMAL(10,2),
            @da DECIMAL(10,2),
            @pf DECIMAL(10,2),
            @it DECIMAL(10,2),
            @deductions DECIMAL(10,2),
            @gross_sal DECIMAL(10,2),
            @netsal DECIMAL(10,2)

    
    SELECT 
        @ename = ename,
        @sal = sal
    FROM Emp
    WHERE empno = @EmpID

    IF @ename IS NULL
    BEGIN
        PRINT 'Employee not found.'
        RETURN
    END

    SET @hra = @sal * 0.10
    SET @da  = @sal * 0.20
    SET @pf  = @sal * 0.08
    SET @it  = @sal * 0.05
    SET @deductions = @pf + @it
    SET @gross_sal = @sal + @hra + @da
    SET @netsal = @gross_sal - @deductions

    PRINT '====================================='
    PRINT '            EMPLOYEE PAYSLIP         '
    PRINT '====================================='
    PRINT 'Employee ID   : ' + CAST(@EmpID AS VARCHAR)
    PRINT 'Employee Name : ' + @ename
    PRINT 'Basic Salary  : ' + CAST(@sal AS VARCHAR)
    PRINT 'HRA (10%)     : ' + CAST(@hra AS VARCHAR)
    PRINT 'DA  (20%)     : ' + CAST(@da AS VARCHAR)
    PRINT 'PF  (8%)      : ' + CAST(@pf AS VARCHAR)
    PRINT 'IT  (5%)      : ' + CAST(@it AS VARCHAR)
    PRINT 'Deductions : ' + CAST(@deductions AS VARCHAR)
    PRINT 'Gross Salary  : ' + CAST(@gross_sal AS VARCHAR)
    PRINT 'Net Salary    : ' + CAST(@netsal AS VARCHAR)
    PRINT '====================================='
END

EXEC sp_generatepayslip 7369;



--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. 
--Display the error message like “Due to Independence day you cannot manipulate data” 
--or "Due To Diwali", you cannot manipulate" etc

--Note: Create holiday table with (holiday_date,Holiday_name). 
--Store at least 4 holiday details. try to match the dates and stop manipulation 

--creating table holidays
CREATE TABLE holiday
(
    holiday_date DATE PRIMARY KEY,
    holiday_name VARCHAR(50)
)

--inserting data into table holidays
INSERT INTO holiday VALUES
('2026-05-27', 'Bakrid'),
('2026-08-15', 'Independence Day'),
('2026-01-14', 'Pongal'),
('2026-11-01', 'Diwali')

--inserting spsl date to check the trigger
INSERT INTO holiday VALUES
('2026-04-29', 'Spl Holiday')


CREATE OR ALTER TRIGGER trg_blockonholiday
ON Emp
AFTER INSERT, UPDATE, DELETE
AS
BEGIN

    DECLARE @today DATE = CAST(GETDATE() AS DATE)
    DECLARE @hname VARCHAR(50)

    SELECT @hname = holiday_name
    FROM holiday
    WHERE holiday_date = @today

    IF @hname IS NOT NULL
    BEGIN
        ROLLBACK TRANSACTION

        DECLARE @msg VARCHAR(200)

        SET @msg = 'Due to ' + @hname + 
                   ', you cannot manipulate EMP table data today.'

        RAISERROR(@msg, 16, 1)
        RETURN
    END
END

INSERT INTO Emp (empno, ename, job, [mgr-id], hiredate, sal, [comm.], deptno)
VALUES (9000, 'TestUser1', 'Clerk', 7788, '2024-01-01', 1000, NULL, 10)

UPDATE Emp
SET sal = sal + 500
WHERE empno = 7369

DELETE FROM Emp
WHERE empno = 7499