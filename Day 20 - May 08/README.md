# Entity Framework Core 

Entity Framework Core and how to use it to interact with a SQL database in a .NET application. We scaffolded a SQL database into a request tracker application.

## Scaffolding the Database

the Scaffold-DbContext command to generate the context and entity classes for the dbEmployeeTracker database.

```bash
Scaffold-DbContext "Data Source=<>;Integrated Security=true;Initial Catalog=<>" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
```

## Database for Employe

```sql
CREATE DATABASE RequestTrackerApp;
GO

use RequestTracker;

  CREATE TABLE Employees(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(30),
	Age INT,
	DOB DATETIME,
	Salary FLOAT,
	Role VARCHAR(30),
)

CREATE TABLE Departments(
	Id INT IDENTITY(1,1) PRIMARY KEY,
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

```
![](./Assets/Screenshot%202024-05-08%20182049.png)
![](./Assets/Screenshot%202024-05-08%20185523.png)


## Interacting with the Database

instances of the dbEmployeeTrackerContext to interact with the database. We performed various operations such as adding, updating, and removing records.

```c#
using RequestTrackerDALLibrary.Model; //Change -> scaffold


namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        RequestTrackerContext context = new RequestTrackerContext();

        private List<Department> _departments;

        public DepartmentRepository()
        {
            _departments = new List<Department>();
        }

        int GenerateId()
        {

            if (_departments.Count == 0)
            {
                return 1;
            }
            int id = _departments.Count;
            return ++id;
        }

        public Department Add(Department item)
        {
            context.Departments.Add(item);
            context.SaveChanges();
            _departments = context.Departments.ToList();
            item = _departments.Find(d => d.Name == item.Name);
            return item;
        }
        public Department Delete(int key)
        {
            var department = _departments.SingleOrDefault(d => d.Id == key);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                _departments = context.Departments.ToList();
                return department;
            }
            return null!;
        }

        public List<Department> GetAll()
        {
            _departments = context.Departments.ToList();
            if (_departments.Count == 0)
                return null!;
            return _departments;
        }

        public Department Get(int key)
        {
            var department = _departments.SingleOrDefault(d => d.Id == key);
            if (department != null)
            {
                return department;
            }
            return null!;
        }

        public Department Update(Department item)
        {
            var department = _departments.SingleOrDefault(d => d.Id == item.Id);
            if (department != null)
            {
                department = item;
                context.Departments.Update(department);
                context.SaveChanges();
                return department;
            }
            return null!;
        }
    }
}

```
```c#
using RequestTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        RequestTrackerContext context = new RequestTrackerContext();
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = context.Employees.ToList();
        }

        int GenerateId()
        {
            if (_employees.Count == 0)
            {
                return 1;
            }
            int id = _employees.Count();
            return ++id;
        }

        public Employee Add(Employee item)
        {
            context.Employees.Add(item);
            context.SaveChanges();
            _employees = context.Employees.ToList();
            if (_employees.Contains(item)) return item;
            return null;
        }

        public Employee Delete(int key)
        {
            _employees = context.Employees.ToList();
            var employee = _employees.SingleOrDefault(d => d.Id == key);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                _employees = context.Employees.ToList();
                return employee;
            }
            return null;
        }

        public List<Employee> GetAll()
        {
            if (_employees.Count == 0)
                return null;
            return _employees;
        }

        public Employee Get(int key)
        {
            var employee = _employees.SingleOrDefault(d => d.Id == key);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }

        public Employee Update(Employee item)
        {
            _employees = context.Employees.ToList();
            var employee = _employees.SingleOrDefault(d => d.Id == item.Id);
            if (employee != null)
            {
                employee = item;
                context.Employees.Update(employee);
                context.SaveChanges();
                _employees = context.Employees.ToList();
                return employee;
            }
            return null;
        }

    }
}


```

