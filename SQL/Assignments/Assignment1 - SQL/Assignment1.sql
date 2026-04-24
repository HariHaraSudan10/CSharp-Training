CREATE DATABASE sql_assignment1;

USE sql_assignment1;

--creating table departments
CREATE TABLE Departments (
    Deptno INT PRIMARY KEY,
    Dname VARCHAR(15) NOT NULL,
    Loc VARCHAR(20)
);

--creating table cliets
CREATE TABLE Clients (
    Client_ID INT PRIMARY KEY,
    Cname VARCHAR(40) NOT NULL,
    Address VARCHAR(30),
    Email VARCHAR(30) UNIQUE,
    Phone VARCHAR(15),  
    Business VARCHAR(20) NOT NULL
);

--creating table employees
CREATE TABLE Employees (
    Empno INT PRIMARY KEY,
    Ename VARCHAR(20) NOT NULL,
    Job VARCHAR(15),
    Salary DECIMAL(7,2) CHECK (Salary > 0),
    Deptno INT FOREIGN KEY REFERENCES Departments(Deptno)
);

--creating table projects
CREATE TABLE Projects (
    Project_ID INT PRIMARY KEY,
    Descr VARCHAR(30) NOT NULL,
    Start_Date DATE,
    Planned_End_Date DATE,
    Actual_End_Date DATE,
    Budget DECIMAL(10,2) CHECK (Budget > 0),
    Client_ID INT,
    CONSTRAINT fk_proj_client 
        FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID),
    CONSTRAINT chk_dates 
        CHECK (
            Actual_End_Date IS NULL 
            OR Planned_End_Date IS NULL 
            OR Actual_End_Date > Planned_End_Date
        )
);

--creating table employee project tasks
CREATE TABLE EmpProjectTasks (
    Project_ID INT,
    Empno INT,
    Start_Date DATE,
    End_Date DATE,
    Task VARCHAR(25) NOT NULL,
    Status VARCHAR(15) NOT NULL,
    CONSTRAINT pk_ept_proj PRIMARY KEY (Project_ID, Empno),
    CONSTRAINT fk_ept_proj FOREIGN KEY (Project_ID)
        REFERENCES Projects(Project_ID),
    CONSTRAINT fk_ept_emp FOREIGN KEY (Empno)
        REFERENCES Employees(Empno),
);

--inserting data into table clients
INSERT INTO Clients (Client_ID, Cname, Address, Email, Phone, Business) VALUES
(1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', '9567880032', 'Manufacturing'),
(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', '8734210090', 'Consultant'),
(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', '7799886655', 'Reseller'),
(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', '9210342219', 'Professional');

--inserting data into table departments
INSERT INTO Departments (Deptno, Dname, Loc) VALUES
(10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai');

--inserting data into table employees
INSERT INTO Employees (Empno, Ename, Job, Salary, Deptno) VALUES
(7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech.Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10);

--inserting data into table projects
INSERT INTO Projects (Project_ID, Descr, Start_Date, Planned_End_Date, Actual_End_Date, Budget, Client_ID) VALUES
(401, 'Inventory', convert(date,'01-04-2011',105), convert(date,'01-10-2011',105), convert(date,'31-10-2011',105), 150000, 1001),
(402, 'Accounting', convert(date,'01-08-2011',105), convert(date,'01-01-2011',105), NULL, 500000, 1002),
(403, 'Payroll', convert(date,'01-10-2011',105), convert(date,'31-12-2011',105), NULL, 75000, 1003),
(404, 'Contact Mgmt', convert(date,'01-11-2011',105), convert(date,'31-12-2011',105), NULL, 50000, 1004);

--inserting data into table employee project tasks
INSERT INTO EmpProjectTasks (Project_ID, Empno, Start_Date, End_Date, Task, Status) VALUES
(401, 7001, CONVERT(DATE,'01-04-2011',105), CONVERT(DATE,'20-04-2011',105), 'System Analysis', 'Completed'),
(401, 7002, CONVERT(DATE,'21-04-2011',105), CONVERT(DATE,'30-05-2011',105), 'System Design', 'Completed'),
(401, 7003, CONVERT(DATE,'01-06-2011',105), CONVERT(DATE,'15-07-2011',105), 'Coding', 'Completed'),
(401, 7004, CONVERT(DATE,'18-07-2011',105), CONVERT(DATE,'01-09-2011',105), 'Coding', 'Completed'),
(401, 7006, CONVERT(DATE,'03-09-2011',105), CONVERT(DATE,'15-09-2011',105), 'Testing', 'Completed'),
(401, 7009, CONVERT(DATE,'18-09-2011',105), CONVERT(DATE,'05-10-2011',105), 'Code Change', 'Completed'),
(401, 7008, CONVERT(DATE,'06-10-2011',105), CONVERT(DATE,'16-10-2011',105), 'Testing', 'Completed'),
(401, 7007, CONVERT(DATE,'06-10-2011',105), CONVERT(DATE,'22-10-2011',105), 'Documentation', 'Completed'),
(401, 7011, CONVERT(DATE,'22-10-2011',105), CONVERT(DATE,'31-10-2011',105), 'Sign off', 'Completed'),
(402, 7010, CONVERT(DATE,'01-08-2011',105), CONVERT(DATE,'20-08-2011',105), 'System Analysis', 'Completed'),
(402, 7002, CONVERT(DATE,'22-08-2011',105), CONVERT(DATE,'30-09-2011',105), 'System Design', 'Completed'),
(402, 7004, CONVERT(DATE,'01-10-2011',105), NULL, 'Coding', 'In Progress');

--selecting from table department
SELECT * FROM Departments;

--selecting from table clients
SELECT * FROM Clients;

--selecting from table employees
SELECT * FROM Employees;

--selecting from table projects
SELECT * FROM Projects;

--selecting from table employee project tasks
SELECT * FROM EmpProjectTasks;

