CREATE DATABASE MiniProjectDB;
USE MiniProjectDB;

CREATE TABLE Users
(
    UserId INT PRIMARY KEY IDENTITY,
    Username VARCHAR(50) UNIQUE,
    Password VARCHAR(50),
    UserType VARCHAR(20)
);
INSERT INTO Users(Username, Password, UserType) 
VALUES
    ('admin','admin123','Admin'),
    ('user1','user123','Customer');

CREATE TABLE TrainDetails
(
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(100),
    FromStation VARCHAR(100),
    ToStation VARCHAR(100),
    TrainClass VARCHAR(20),
    Availability INT,
    Charges DECIMAL(10,2),
    IsDeleted BIT DEFAULT 0
);
INSERT INTO TrainDetails VALUES
(101,'Chennai Express','Chennai','Bangalore','Sleeper',100,500,0),
(102,'Kovai Express','Chennai','Coimbatore','3AC',50,1200,0),
(103,'Nilgiri Express','Chennai','Ooty','2AC',30,2000,0),
(104,'Argentina Express','Chennai','Rosario','1AC',20,85000,0),
(105,'Hogwarts Express','London','Hogwarts','Magic Class',40,9999,0);

CREATE TABLE BookingDetails
(
    BookingId INT PRIMARY KEY IDENTITY,
    BookDate DATE,
    TravelDate DATE,
    TrainNo INT,
    TravelClass VARCHAR(20),
    PassengerCount INT CHECK (PassengerCount <= 3),
    Amount DECIMAL(10,2),

    FOREIGN KEY (TrainNo)
    REFERENCES TrainDetails(TrainNo)
);

CREATE TABLE CancellationDetails
(
    CId INT PRIMARY KEY IDENTITY,
    BookingId INT,
    NoTickets INT,
    RefundAmount DECIMAL(10,2),

    FOREIGN KEY (BookingId)
    REFERENCES BookingDetails(BookingId)
);

ALTER TABLE BookingDetails
ADD Status VARCHAR(20) DEFAULT 'Booked';