using System.Collections.Generic;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployeeList();
    }
}
