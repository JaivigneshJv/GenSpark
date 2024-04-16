namespace EmployeeManagementModelLibrary
{
    public class XYZ : Organization
    {
        public XYZ(int empId, string empName, string dept, string desig, double basicSalary, int workExperience)
            : base(empId, empName, dept, desig, basicSalary, workExperience)
        {
        }

        public override double EmployeePF(double basicSalary)
        {
            double employeePF = basicSalary * 0.12;
            double employerContribution = basicSalary * 0.12;

            return employeePF + employerContribution;
        }
      
        public override string LeaveDetails()
        {
            return "Leave Details:\n2 days of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Privilege Leave per year";
        }

        public override double GratuityAmount(int workExperience, double basicSalary)
        {
            return 0;
        }
    }
}
