using System;

namespace RequestTrackerBLLibrary.Exceptions
{
    public class DepartmentNotFoundException : Exception
    {
        public DepartmentNotFoundException(int departmentId)
            : base($"Department with ID {departmentId} not found.")
        {
        }

        public DepartmentNotFoundException(string departmentName)
            : base($"Department with name '{departmentName}' not found.")
        {
        }
    }
}
