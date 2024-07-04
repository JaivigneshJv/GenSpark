CREATE DATABASE dbDocker;

\c dbDocker

CREATE TABLE Department (
    dept_id SERIAL PRIMARY KEY,
    dept_name VARCHAR(100) NOT NULL
);

CREATE TABLE Employee (
    emp_id SERIAL PRIMARY KEY,
    emp_name VARCHAR(100) NOT NULL,
    age INT,
    phone VARCHAR(15),
    dept_id INT REFERENCES Department(dept_id)
);

CREATE TABLE Salary (
    emp_id INT PRIMARY KEY,
    salary NUMERIC,
    FOREIGN KEY (emp_id) REFERENCES Employee(emp_id)
);

INSERT INTO Department (dept_name) VALUES ('HR'), ('Engineering'), ('Marketing');

INSERT INTO Employee (emp_name, age, phone, dept_id) VALUES
('Jv', 30, '111-111-1111', 1),
('Rk', 25, '999-999-9999', 2),
('Ash', 35, '555-555-5555', 3);

INSERT INTO Salary (emp_id, salary) VALUES
(1, 50000),
(2, 60000),
(3, 70000);
