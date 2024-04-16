using EmployeeManagementModelLibrary;

namespace EmployeeManagement

{
    class Program
    {
        //Exploring List
        private static List<Organization> employees = new List<Organization>();

        static void Main(string[] args)
        {
            int choice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Employee Management System\n");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Update Employee Details");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Calculate Gratuity Amount");
                Console.WriteLine("6. Calculate Employee PF");
                Console.WriteLine("7. View Leave Details");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AddEmployee();
                            break;
                        case 2:
                            Console.Clear();
                            ViewEmployees();
                            break;
                        case 3:
                            Console.Clear();
                            UpdateEmployee();
                            break;
                        case 4:
                            Console.Clear();
                            DeleteEmployee();
                            break;
                        case 5:
                            Console.Clear();
                            CalculateGratuityAmount();
                            break;
                        case 6:
                            Console.Clear();
                            CalculateEmployeePF();
                            break;
                        case 7:
                            Console.Clear();
                            ViewLeaveDetails();
                            break;
                        case 8:
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            } while (choice != 8);
        }

        private static void ClearConsole()
        {
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadLine();
        }

        private static void AddEmployee()
        {

            Console.Write("Enter organization type (ABC/XYZ): ");
            string? orgType = Console.ReadLine()?.Trim().ToUpper();

            Console.Write("Enter employee ID: ");
            int empId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter employee name: ");
            string? empName = Console.ReadLine();

            Console.Write("Enter department: ");
            string? dept = Console.ReadLine();

            Console.Write("Enter designation: ");
            string? desig = Console.ReadLine();

            Console.Write("Enter basic salary: ");
            double basicSalary = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter work experience (in years): ");
            int workExperience = int.Parse(Console.ReadLine() ?? "0");

            Organization? employee = null;

            if (orgType == "ABC")
            {
                employee = new ABC(empId, empName!, dept!, desig!, basicSalary, workExperience);
            }
            else if (orgType == "XYZ")
            {
                employee = new XYZ(empId, empName!, dept!, desig!, basicSalary, workExperience);
            }
            else
            {
                Console.WriteLine("Invalid organization type.");
                return;
            }

            employees.Add(employee);
            Console.WriteLine("\n Employee added successfully.");
            ClearConsole();
        }

        private static void ViewEmployees()
        {
            Console.WriteLine("List of All Employees:\n");
            foreach (var employee in employees)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Organization Type: {employee.GetType().Name}");
                Console.WriteLine($"EmpID: {employee.EmpId}");
                Console.WriteLine($"Name: {employee.EmpName}");
                Console.WriteLine($"Dept: {employee.Dept}");
                Console.WriteLine($"Desig: {employee.Desig}");
                Console.WriteLine($"Basic Salary: {employee.BasicSalary}");
                Console.WriteLine($"Work Experience: {employee.WorkExperience}");
                Console.WriteLine("---------------------------------------------------\n");
            }
            ClearConsole();
        }

        private static void UpdateEmployee()
        {
            Console.Write("Enter employee ID to update: ");
            int empId = int.Parse(Console.ReadLine() ?? "0");

            Organization? employee = employees.Find(e => e.EmpId == empId);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine($"Updating details for EmpID: {empId}");
            Console.Write($"Enter new employee name (current: {employee.EmpName}): ");
            string? newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                employee.EmpName = newName;
            }

            Console.Write($"Enter new department (current: {employee.Dept}): ");
            string? newDept = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDept))
            {
                employee.Dept = newDept;
            }

            Console.Write($"Enter new designation (current: {employee.Desig}): ");
            string? newDesig = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDesig))
            {
                employee.Desig = newDesig;
            }

            Console.Write($"Enter new basic salary (current: {employee.BasicSalary}): ");
            if (double.TryParse(Console.ReadLine(), out double newBasicSalary))
            {
                employee.BasicSalary = newBasicSalary;
            }

            Console.Write($"Enter new work experience (current: {employee.WorkExperience} years): ");
            if (int.TryParse(Console.ReadLine(), out int newWorkExperience))
            {
                employee.WorkExperience = newWorkExperience;
            }

            Console.WriteLine("Employee details updated successfully.");
            ClearConsole();

        }

        private static void DeleteEmployee()
        {
            Console.Write("Enter employee ID to delete: ");
            int empId = int.Parse(Console.ReadLine() ?? "0");

            Organization? employee = employees.Find(e => e.EmpId == empId);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            employees.Remove(employee);
            Console.WriteLine("Employee deleted successfully.");

            ClearConsole();
        }

        private static void CalculateGratuityAmount()
        {
            Console.Write("Enter employee ID to calculate gratuity amount: ");
            int empId = int.Parse(Console.ReadLine() ?? "0");

            Organization? employee = employees.Find(e => e.EmpId == empId);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            double gratuityAmount = employee.GratuityAmount(employee.WorkExperience, employee.BasicSalary);
            if (gratuityAmount == 0)
            {
                Console.WriteLine("Gratuity Amount not applicable for this employee.");
                return;
            }
            Console.WriteLine($"Gratuity Amount for EmpID {empId}: {gratuityAmount}\n");
            ClearConsole();

        }

        private static void CalculateEmployeePF()
        {
            Console.Write("Enter employee ID to calculate employee PF: ");
            int empId = int.Parse(Console.ReadLine() ?? "0");

            Organization? employee = employees.Find(e => e.EmpId == empId);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            double employeePF = employee.EmployeePF(employee.BasicSalary);
            Console.WriteLine($"\nEmployee PF for EmpID {empId}: {employeePF}\n");

            ClearConsole();

        }

        private static void ViewLeaveDetails()
        {
            Console.Write("Enter employee ID to view leave details: ");
            int empId = int.Parse(Console.ReadLine() ?? "0");

            Organization? employee = employees.Find(e => e.EmpId == empId);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            string leaveDetails = employee.LeaveDetails();
            Console.WriteLine($"\nLeave Details for EmpID {empId}:\n{leaveDetails}\n");

            ClearConsole();

        }
    }
}
