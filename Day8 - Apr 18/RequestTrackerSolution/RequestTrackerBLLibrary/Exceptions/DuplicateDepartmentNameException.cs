namespace RequestTrackerBLLibrary.Exceptions
{
    public class DuplicateDepartmentNameException : Exception
    {
        public DuplicateDepartmentNameException(string departmentName)
            : base($"Department name '{departmentName}' already exists.")
        {
        }
    }
}
