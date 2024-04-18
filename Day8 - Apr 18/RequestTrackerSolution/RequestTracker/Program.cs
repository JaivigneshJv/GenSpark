using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

class Program
{
    public static void ClearConsole()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    static void Main(string[] args)
    {
        var departmentRepository = new DepartmentRepository();
        var employeeRepository = new EmployeeRepository();
        var departmentService = new DepartmentBL(departmentRepository);
        var employeeService = new EmployeeBL(employeeRepository);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Employee Management System");
            Console.WriteLine("1. Manage Departments");
            Console.WriteLine("2. Manage Employees");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose an option:");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        ManageDepartments(departmentService);
                        break;
                    case 2:
                        ManageEmployees(employeeService, departmentService);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }

    static void ManageDepartments(IDepartmentService departmentService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Department Management");
            Console.WriteLine("\n1. Add Department");
            Console.WriteLine("2. Change Department Name");
            Console.WriteLine("3. List Departments");
            Console.WriteLine("4. Go Back");
            Console.WriteLine("Choose an option:");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        AddDepartment(departmentService);
                        break;
                    case 2:
                        ChangeDepartmentName(departmentService);
                        break;
                    case 3:
                        ListDepartments(departmentService);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }

    static void ManageEmployees(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Employee Management");
            Console.WriteLine("\n1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. List Employees");
            Console.WriteLine("5. Go Back");
            Console.WriteLine("Choose an option:");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        AddEmployee(employeeService, departmentService);
                        break;
                    case 2:
                        UpdateEmployee(employeeService);
                        break;
                    case 3:
                        DeleteEmployee(employeeService);
                        break;
                    case 4:
                        ListEmployees(employeeService);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }

    static void AddDepartment(IDepartmentService departmentService)
    {
        Console.WriteLine("\nEnter Department Name:");
        string? departmentName = Console.ReadLine();
        if (departmentName == null)
        {
            Console.WriteLine("Invalid name. Try again.");
            return;
        }

        Console.WriteLine("Enter Department Head ID:");
        if (!int.TryParse(Console.ReadLine(), out int headId))
        {
            Console.WriteLine("Invalid head ID. Try again.");
            return;
        }

        var department = new Department
        {
            Name = departmentName,
            DepartmentHead = headId
        };

        try
        {
            int id = departmentService.AddDepartment(department);
            Console.WriteLine($"Department added with ID {id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        ClearConsole();

    }

    static void ChangeDepartmentName(IDepartmentService departmentService)
    {
        Console.WriteLine("\nEnter existing department name:");
        string? oldName = Console.ReadLine();
        if (oldName == null)
        {
            Console.WriteLine("Invalid input. Try again.");
            return;
        }

        Console.WriteLine("Enter new department name:");
        string? newName = Console.ReadLine();
        if (newName == null)
        {
            Console.WriteLine("Invalid input. Try again.");
            return;
        }

        try
        {
            departmentService.ChangeDepartmentName(oldName, newName);
            Console.WriteLine("Department name changed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        ClearConsole();

    }

    static void ListDepartments(IDepartmentService departmentService)
    {
        var departments = departmentService.GetDepartmentList();
        foreach (var department in departments)
        {
            Console.WriteLine(department.ToString());
        }
        ClearConsole();

    }

    static void AddEmployee(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        Console.WriteLine("\nEnter Employee Name:");
        string? employeeName = Console.ReadLine();
        if (employeeName == null)
        {
            Console.WriteLine("Invalid name. Try again.");
            return;
        }

        Console.WriteLine("Enter Employee Salary:");
        if (!double.TryParse(Console.ReadLine(), out double salary))
        {
            Console.WriteLine("Invalid salary. Try again.");
            return;
        }

        Console.WriteLine("Enter Employee Date of Birth (yyyy-mm-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            Console.WriteLine("Invalid date. Try again.");
            return;
        }

        Console.WriteLine("Enter Department ID:");
        if (!int.TryParse(Console.ReadLine(), out int departmentId))
        {
            Console.WriteLine("Invalid department ID. Try again.");
            return;
        }

        try
        {
            var department = departmentService.GetDepartmentById(departmentId);
            var employee = new Employee
            {
                Name = employeeName,
                Salary = salary,
                DateOfBirth = dob,
                EmployeeDepartment = department
            };

            int id = employeeService.AddEmployee(employee);
            Console.WriteLine($"Employee added with ID {id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        ClearConsole();

    }

    static void UpdateEmployee(IEmployeeService employeeService)
    {
        Console.WriteLine("\nEnter Employee ID:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Try again.");
            return;
        }

        try
        {
            var employee = employeeService.GetEmployeeById(id);
            Console.WriteLine("Enter new Employee Name:");
            string? newName = Console.ReadLine();
            if (newName != null)
            {
                employee.Name = newName;
            }

            Console.WriteLine("Enter new Employee Salary:");
            if (double.TryParse(Console.ReadLine(), out double newSalary))
            {
                employee.Salary = newSalary;
            }

            employeeService.UpdateEmployee(employee);
            Console.WriteLine("Employee updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        ClearConsole();

    }

    static void DeleteEmployee(IEmployeeService employeeService)
    {
        Console.WriteLine("\nEnter Employee ID:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Try again.");
            return;
        }

        try
        {
            employeeService.DeleteEmployee(id);
            Console.WriteLine("Employee deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        ClearConsole();

    }

    static void ListEmployees(IEmployeeService employeeService)
    {
        var employees = employeeService.GetEmployeeList();
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
        ClearConsole();
    }

}
