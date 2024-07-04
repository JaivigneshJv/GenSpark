

# PostgreSQL Docker Setup

This guide covers how to set up a PostgreSQL database using Docker, create tables, insert data, and execute queries. It also includes instructions on how to run SQL commands from a file.

Reference: [offical docs](https://github.com/docker-library/docs/blob/master/postgres/README.md)

## Steps

### 1. Pull the PostgreSQL Docker Image

```sh
docker pull postgres
```

### 2. Run a PostgreSQL Container

```sh
docker run --name dbDocker -e POSTGRES_PASSWORD=mysecretpassword -d postgres
```

### 3. Access the PostgreSQL Container

```sh
docker exec -it dbDocker psql -U postgres
```

run db queries in here

(Or)

### 4. Create a Database and Tables, Insert Data

#### Create the `setup.sql` File

Create a file named `setup.sql` with the following content:

```sql
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
```

### 5. Copy the SQL File into the Container

```sh
docker cp setup.sql dbDocker:/setup.sql
```

### 6. Execute the SQL Commands from the File

```sh
docker exec -it dbDocker psql -U postgres -d dbDocker -f /setup.sql
```

### 7. Execute Queries

To execute a query that prints `employee_name`, `age`, `phone`, `department_name`, and `salary`, run:

```sh
docker exec -it dbDocker psql -U postgres -d dbDocker
```

Then, in the PostgreSQL interactive terminal, execute:

```sql
SELECT e.emp_name AS employee_name, e.age, e.phone, d.dept_name AS department_name, s.salary
FROM Employee e
JOIN Department d ON e.dept_id = d.dept_id
JOIN Salary s ON e.emp_id = s.emp_id;
```
