using System.Collections.Generic;
using System.Linq;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public Employee Add(Employee entity)
        {
            _employees.Add(entity);
            return entity;
        }

        public Employee Update(Employee entity)
        {
            var existingEmployee = GetById(entity.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = entity.Name;
                existingEmployee.Salary = entity.Salary;
                existingEmployee.EmployeeDepartment = entity.EmployeeDepartment;
                existingEmployee.Role = entity.Role;
                existingEmployee.Type = entity.Type;
                return existingEmployee;
            }

            throw new Exception("Failed to update employee.");
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
