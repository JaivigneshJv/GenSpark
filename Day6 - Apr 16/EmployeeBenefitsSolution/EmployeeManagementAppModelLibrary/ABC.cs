namespace EmployeeManagementModelLibrary
{
    public class ABC : Organization
    {
        public ABC(int empId, string empName, string dept, string desig, double basicSalary, int workExperience)
            : base(empId, empName, dept, desig, basicSalary, workExperience)
        {
        }

        public override double EmployeePF(double basicSalary)
        {
            double employeePF = basicSalary * 0.12;
            //double employerContribution = basicSalary * 0.0833;
            double pensionFund = basicSalary * 0.0367;

            return basicSalary - (employeePF + pensionFund);
        }

        public override string LeaveDetails()
        {
            return "Leave Details:\n1 day of Casual Leave per month\n12 days of Sick Leave per year\n10 days of Privilege Leave per year";
        }

        public override double GratuityAmount(int workExperience, double basicSalary)
        {
            if (workExperience < 5)
            {
                return 0; 
            }
            else if (workExperience >= 5 && workExperience <= 10)
            {
                return basicSalary; 
            }
            else if (workExperience > 10 && workExperience <= 20)
            {
                return 2 * basicSalary; 
            }
            else
            {
                return 3 * basicSalary;
            }
        }
    }
}
