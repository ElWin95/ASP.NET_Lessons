CREATE DATABASE ADONET
USE ADONET

CREATE TABLE Students(
Id int primary key identity,
Name nvarchar(50),
Age int
)

INSERT INTO Students VALUES
('Lorem',25)

INSERT INTO Students VALUES
('Ipsum',55),
('Doler',16)

--SELECT Name FROM Students WHERE Id=1

SELECT Name FROM Students