using CRUDModelLibrary;

namespace CRUDApp
{
    internal class Program
    {
        private Employee[] employees;

        public Program()
        {
            employees = new Employee[3];
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Play Game");
            Console.WriteLine("7.Repeating Number");
            Console.WriteLine("0. Exit \n\n ");
        }

        private void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                bool inputValidation = false;
                do
                {
                    Console.Write("Please select an option: ");
                    string? input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid choice. Try again \n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        PrintMenu();
                        continue;
                    }
                    if (!int.TryParse(input, out choice))
                    {
                        Console.WriteLine("Invalid choice. Try again \n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        PrintMenu();
                        continue;
                    }
                    inputValidation = true;
                }
                while (!inputValidation);

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        Game.GuessGame();
                        break;
                    case 7:
                        RepeatingNumbers.Problem();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
                Console.WriteLine("\n Press any key to continue...");
                Console.ReadKey();
            } while (choice != 0);
        }

        private void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("---------- Add Employee --------- \n");
            int index = Array.FindIndex(employees, emp => emp == null);
            if (index == -1)
            {
                Array.Resize(ref employees, employees.Length + 1);
                index = employees.Length - 1;
            }

            Employee newEmployee = CreateEmployee(index);
            employees[index] = newEmployee;

            Console.WriteLine("Employee added successfully");

            Console.WriteLine("\nDo you want to add more employees? (Y/N)");
            string? choice = Console.ReadLine();
            if (choice != null && choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                AddEmployee();
            }
        }

        private void PrintAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("---------- All Employees --------- \n");

            if (employees[0] == null)
            {
                Console.WriteLine("No employees available");
                return;
            }

            foreach (var employee in employees)
            {
                if (employee != null)
                    PrintEmployee(employee);
            }
        }

        private Employee CreateEmployee(int id)
        {

            Employee employee = new Employee
            {
                Id = 101 + id
            };
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        private void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------\n");
        }

        private int GetIdFromConsole()
        {
            int id = 0;
            Console.Write("Please enter the employee Id: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }

        private void SearchAndPrintEmployee()
        {
            Console.Clear();
            Console.WriteLine("---------- Find Employee --------- \n");
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such employee is present");
                return;
            }
            PrintEmployee(employee);
        }

        private Employee? SearchEmployeeById(int id)
        {
            foreach (var employee in employees)
            {
                if (employee != null && employee.Id == id)
                {
                    return employee;
                }
            }
            return null;
        }

        private void UpdateEmployee()
        {
            Console.Clear();
            Console.WriteLine("---------- Update Employee --------- \n");
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such employee is present");
                return;
            }

            Console.WriteLine("\n Current Employee Details:");
            PrintEmployee(employee);

            employee.BuildEmployeeFromConsole();
            Console.WriteLine("Employee updated successfully");
        }

        private void DeleteEmployee()
        {
            Console.Clear();
            Console.WriteLine("---------- Delete Employee --------- \n");
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such employee is present");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    // Shift remaining employees down
                    for (int j = i; j < employees.Length - 1; j++)
                    {
                        employees[j] = employees[j + 1];
                    }
                    employees[employees.Length - 1] = null!;

                    Console.WriteLine("Employee deleted successfully");
                    return;
                }
            }
        }

        private static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}
