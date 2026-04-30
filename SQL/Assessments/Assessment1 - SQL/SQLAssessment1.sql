CREATE DATABASE Assessment
USE Assessment

--Create a book table with id as primary key and provide the appropriate data type to other attributes 
--.isbn no should be unique for each book


--creating table books
CREATE TABLE books 
(
	id INT PRIMARY KEY,
	title VARCHAR(30),
	author VARCHAR(30),
	isbn BIGINT UNIQUE,
	published_date DATETIME
);

--creating table reviews 
CREATE TABLE reviews
(
	id INT PRIMARY KEY,
	book_id INT,
	reviewer_name VARCHAR(30),
	content VARCHAR(100),
	rating INT,
	published_date DATETIME
	FOREIGN KEY (book_id) REFERENCES books(id) 
);

--inserting data into table books
INSERT INTO books (id, title, author, isbn, published_date)
VALUES (1, 'My First SQL book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17'),
	   (2, 'My Second SQL book', 'John Mayer', 857300923713, '1972-07-03 09:22:45'),
	   (3, 'My Third SQL book', 'Cary Flint', 523120967812, '2015-10-18 10:05:44');

--inserting data into table reviews
INSERT INTO reviews(id, book_id, reviewer_name, content, rating, published_date)
VALUES(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11.1'),
	  (2, 2, 'John Smith', 'My second review', 5,'2017-10-13 15:05:12.6'),
	  (3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');


--Write a query to fetch the details of the books written by author whose name ends with er.
SELECT * FROM books WHERE author LIKE '%er';

--Display the Title ,Author and ReviewerName for all the books from the above table
SELECT b.title Title, b.author Author, r.reviewer_name ReviewerName 
FROM books b JOIN reviews r ON b.id = r.book_id;

--2.Display the reviewer name who reviewed more than one book
SELECT reviewer_name ReviewerName FROM reviews GROUP BY reviewer_name HAVING COUNT(book_id) > 1;

--creating table customers
CREATE TABLE customers
(
	id INT PRIMARY KEY,
	name VARCHAR(30),
	age INT,
	address VARCHAR(30),
	salary DECIMAL(10,2)
);

--inserting data into table customers
INSERT INTO customers(id, name, age, address, salary)
VALUES(1,'Ramesh', 32, 'Ahmedabad', 2000),
	  (2, 'Khilan', 25, 'Delhi', 1500),
	  (3, 'Kaushik', 23, 'Kota', 2000),
	  (4, 'Chaitali', 25, 'Mumbai',6500),
	  (5, 'Hardik', 27, 'Bhopal', 8500),
	  (6, 'Komal', 22, 'MP', 4500),
	  (7, 'Muffy', 24, 'Indore', 10000);

--creating table orders
CREATE TABLE orders
(
	oid INT PRIMARY KEY,
	date DATETIME,
	customer_id INT,
	amount DECIMAL(10,2)
	FOREIGN KEY(customer_id) REFERENCES customers(id)
);

--inserting data into table orders
INSERT INTO orders(oid, date, customer_id, amount)
VALUES(102, '2009-10-08 00:00:00', 3, 3000),
	  (100, '2009-10-08 00:00:00', 3, 1500),
	  (101, '2009-11-20 00:00:00', 2, 1560),
	  (103, '2008-05-20 00:00:00', 4, 2060);

--3.Display the Name for the customer from above customer table 
--who live in same address which has character o anywhere in address
SELECT name Name FROM customers
WHERE address LIKE '%o%';

--4.Write a query to display the Date,Total no of customer placed order on same Date
SELECT date, COUNT(customer_id) TotalCustomers FROM orders GROUP BY date; 

--creating table employee
CREATE TABLE employee
(
	id INT PRIMARY KEY,
	name VARCHAR(30),
	age INT,
	address VARCHAR(30),
	salary DECIMAL(10,2)
);

--inserting data into employee
INSERT INTO employee(id, name, age, address, salary)
VALUES(1,'Ramesh', 32, 'Ahmedabad', 2000),
	  (2, 'Khilan', 25, 'Delhi', 1500),
	  (3, 'Kaushik', 23, 'Kota', 2000),
	  (4, 'Chaitali', 25, 'Mumbai',6500),
	  (5, 'Hardik', 27, 'Bhopal', 8500),
	  (6, 'Komal', 22, 'MP', null),
	  (7, 'Muffy', 24, 'Indore', null);

--5.Display the Names of the Employee in lower case, whose salary is null
SELECT LOWER(name) Name FROM employee WHERE salary IS Null;

--creating table studentdetails
CREATE TABLE studentdetails
(
	resigterno INT,
	name VARCHAR(20),
	age INT,
	qualification VARCHAR(20),
	mobileno BIGINT,
	mail_id VARCHAR(20),
	location VARCHAR(20),
	gender VARCHAR(10)
)

--inserting data into table student details
INSERT INTO studentdetails(resigterno, name, age, qualification, mobileno, mail_id, location, gender)
VALUES(2,'sai',22,'B.E',9952836777,'sai@gmail.com','chennai','m'),
	  (3,'kumar', 20,'BSC',7890125648,'kumar@gmail.com','madurai','m'),
	  (4,'selvi',22,'B.Tech',8904567342,'selvi@gmail.com','selam', 'f'),
	  (5,'nisha', 25,'M.E',7834672310, 'nisha@gmail.com','theni','f'),
	  (6,'saisaran',21,'B.A',7890345678,'saran@gmail.com','madurai','f'),
	  (7,'tom',23,'BCA',89012345675,'tom@gmail.com','pune','m')

--Write a sql server query to display the Gender,Total no of male and female from the above relation
SELECT gender Gender, COUNT(gender) Count FROM studentdetails GROUP BY gender;