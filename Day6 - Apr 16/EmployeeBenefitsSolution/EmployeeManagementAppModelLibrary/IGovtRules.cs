namespace EmployeeManagementModelLibrary
{
    public interface IGovtRules
    {
        double EmployeePF(double basicSalary);
        string LeaveDetails();
        double GratuityAmount(int workExperience, double basicSalary);

    }
}
