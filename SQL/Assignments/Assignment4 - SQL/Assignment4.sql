CREATE DATABASE sql_assignment4

USE sql_assignment4

--creating table student
CREATE TABLE student(Sid INT PRIMARY KEY, Sname varchar(15));

--creating table Marks
CREATE TABLE marks(Mid INT PRIMARY KEY, Sid INT , Score INT, FOREIGN KEY(Sid) REFERENCES student(Sid));

--inserting data into student
INSERT INTO student (Sid, Sname) VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

--inserting data into marks
INSERT INTO marks (Mid, Sid, Score) VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

--1.Write a T-SQL Program to find the factorial of a given number.
DECLARE @num INT = 5
DECLARE @fact INT = 1
DECLARE @i INT = 1

WHILE @i <= @num
BEGIN 
	SET @fact = @fact * @i
	SET @i = @i+1
END

SELECT @num Number, @fact Factorial;

--2.	Create a stored procedure to generate multiplication table 
--that accepts a number and generates up to a given number. 
CREATE OR ALTER PROCEDURE GenerateMultiplicationTable
    @num INT,
    @tnum INT
AS
BEGIN
    DECLARE @i INT = 1

    WHILE @i <= @tnum
    BEGIN
        PRINT CAST(@num AS VARCHAR) + ' x ' + 
              CAST(@i AS VARCHAR) + ' = ' + 
              CAST(@num * @i AS VARCHAR)

        SET @i = @i + 1
    END
END
	
EXEC GenerateMultiplicationTable 10,10;

--3. Create a function to calculate the status of the student. 
--If student score >=50 then pass, else fail. Display the data neatly
CREATE FUNCTION fn_studentstatus (@score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @result VARCHAR(10)
    IF @score >= 50
    SET @result = 'Pass'
    ELSE
    SET @result = 'Fail'
    RETURN @result
END
SELECT  s.Sid ID, s.Sname Name, m.Score,dbo.fn_studentStatus(m.Score) Status 
FROM student s JOIN marks m ON s.Sid = m.Sid;