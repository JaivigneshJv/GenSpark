namespace EmployeeManagementModelLibrary
{
    public class Organization : IGovtRules
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Dept { get; set; }
        public string Desig { get; set; }
        public double BasicSalary { get; set; }
        public int WorkExperience { get; set; }

        public Organization(int empId, string empName, string dept, string desig, double basicSalary, int workExperience)
        {
            EmpId = empId;
            EmpName = empName;
            Dept = dept;
            Desig = desig;
            BasicSalary = basicSalary;
            WorkExperience = workExperience;
        }

        public virtual double EmployeePF(double basicSalary)
        {
            return 0; 
        }

        public virtual string LeaveDetails()
        {
            return string.Empty; 
        }

        public virtual double GratuityAmount(int workExperience, double basicSalary)
        {
            return 0;
        }
    }

}
