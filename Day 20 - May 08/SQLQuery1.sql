CREATE DATABASE RequestTracker;
GO

use RequestTracker;

CREATE TABLE Employees(
	Id INT PRIMARY KEY,
	Name VARCHAR(30),
	Age INT,
	DOB DATETIME,
	Salary FLOAT,
	Role VARCHAR(30),
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY,
	Name VARCHAR(30),
	DepartmentHead INT,
)

CREATE TABLE Requests(
	Id INT PRIMARY KEY,
	RequestTest VARCHAR(50),
	RaisedBy INT,
	Status VARCHAR(50),
	ClosedBy INT,
	RaisedDate DATETIME,
	ClosedDate DATETIME
)


ALTER TABLE Employees
ADD EmployeeDepartment INT FOREIGN KEY REFERENCES Departments(Id);

