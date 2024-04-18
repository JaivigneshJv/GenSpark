using System;
using System.Collections.Generic;
using System.Linq;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        private readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL(IRepository<int, Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public int AddEmployee(Employee employee)
        {
            // Add employee and return its ID
            var result = _employeeRepository.Add(employee);
            return result.Id;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            // Update employee and return the updated employee
            var updatedEmployee = _employeeRepository.Update(employee);
            if (updatedEmployee == null)
            {
                throw new Exceptions.EmployeeNotFoundException(employee.Id);
            }
            return updatedEmployee;
        }

        public void DeleteEmployee(int id)
        {
            // Check if employee exists
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new Exceptions.EmployeeNotFoundException(id);
            }

            // Delete employee
            _employeeRepository.Delete(id);
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new Exceptions.EmployeeNotFoundException(id);
            }
            return employee;
        }

        public List<Employee> GetEmployeeList()
        {
            return _employeeRepository.GetAll().ToList();
        }
    }
}
