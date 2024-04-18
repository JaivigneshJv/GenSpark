using System;

namespace RequestTrackerBLLibrary.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(int employeeId)
            : base($"Employee with ID {employeeId} not found.")
        {
        }
    }
}
