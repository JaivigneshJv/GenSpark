using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private static Employee? CurrentLoggedInEmployee;
        private readonly IEmployeeLoginBL employeeLoginBL;
        private readonly IRequestBL requestBL;

        public Program()
        {
            employeeLoginBL = new EmployeeLoginBL();
            requestBL = new RequestBL();
            CurrentLoggedInEmployee = null;
        }

        static async Task Main(string[] args)
        {
            Program program = new Program();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Request Tracker");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await program.GetLoginDetails();
                        break;
                    case "2":
                        await program.GetRegisterDetails();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        async Task GetLoginDetails()
        {
            Console.Clear();
            Console.WriteLine("-----Login-----");
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string? password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }

        async Task GetRegisterDetails()
        {
            Console.Clear();
            Console.WriteLine("-----Register-----");
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string? password = Console.ReadLine() ?? "";
            await EmployeeRegisterAsync(id, password);
        }

        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            var result = await employeeLoginBL.Login(employee);
            if (result)
            {
                CurrentLoggedInEmployee = employee;
                await Console.Out.WriteLineAsync("Login Success");
                await ManageRequests();
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }

        async Task EmployeeRegisterAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username, Role = "User" };
            var result = await employeeLoginBL.Register(employee);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Registration Success with ID " + result.Id);
            }
            else
            {
                Console.Out.WriteLine("Registration Failed");
            }
        }

        async Task ManageRequests()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Request Management Menu");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. Update Request");
                Console.WriteLine("3. View Request Details");
                Console.WriteLine("4. View All Requests");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddRequest();
                        break;
                    case "2":
                        await UpdateRequest();
                        break;
                    case "3":
                        await ViewRequestDetails();
                        break;
                    case "4":
                        await ViewAllRequests();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        async Task AddRequest()
        {
            Console.WriteLine("Enter Request Details:");
            Console.Write("Request Message: ");
            string? requestMessage = Console.ReadLine() ?? "";
            DateTime currentDateTime = DateTime.Now;
            DateTime requestDate = currentDateTime;

            Request request = new Request
            {
                RequestMessage = requestMessage,
                RequestDate = requestDate,
                RequestStatus = "Opened",
                RequestRaisedBy = CurrentLoggedInEmployee.Id,
                RequestClosedBy = CurrentLoggedInEmployee.Id
            };

            var Addrequest = await requestBL.AddRequest(request);
            Console.WriteLine("Request Added Successfully with ID : " + Addrequest.RequestNumber);
        }

        async Task UpdateRequest()
        {
            Console.WriteLine("Enter Request Number to Update:");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var requestToUpdate = await requestBL.GetRequest(requestNumber);
            if (requestToUpdate == null)
            {
                Console.WriteLine("Request not found!");
                return;
            }
               if(CurrentLoggedInEmployee.Role != "Admin" && requestToUpdate.RequestRaisedBy != CurrentLoggedInEmployee.Id)
            {
                Console.WriteLine("You are not authorized to update this request!");
                return;
            }

            Console.Write("Request Status: ");
            string? requestStatus = Console.ReadLine() ?? "";
 
            await requestBL.UpdateRequest(requestToUpdate, requestStatus);
            Console.WriteLine("Request Updated Successfully!");
        }

       

        async Task ViewRequestDetails()
        {
            Console.WriteLine("Enter Request Number to View Details:");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var requestDetails = await requestBL.GetRequest(requestNumber);
            if (requestDetails == null)
            {
                Console.WriteLine("Request not found!");
                return;
            }

            Console.WriteLine($"Request Number: {requestDetails.RequestNumber}");
            Console.WriteLine($"Request Message: {requestDetails.RequestMessage}");
            Console.WriteLine($"Request Date: {requestDetails.RequestDate}");
            Console.WriteLine($"Closed Date: {requestDetails.ClosedDate}");
            Console.WriteLine($"Request Status: {requestDetails.RequestStatus}");
            Console.WriteLine($"Raised By Employee Id: {requestDetails.RequestRaisedBy}");
            Console.WriteLine($"Closed By Employee Id: {requestDetails.RequestClosedBy}");
        }

        async Task ViewAllRequests()
        {
            var allRequests = await requestBL.GetAllRequests();
            if (allRequests.Count == 0)
            {
                Console.WriteLine("No requests found!");
                return;
            }

            Console.WriteLine("All Requests:");
            foreach (var request in allRequests)
            {
                Console.WriteLine($"Request Number: {request.RequestNumber}");
                Console.WriteLine($"Request Message: {request.RequestMessage}");
                Console.WriteLine($"Request Date: {request.RequestDate}");
                Console.WriteLine($"Closed Date: {request.ClosedDate}");
                Console.WriteLine($"Request Status: {request.RequestStatus}");
                Console.WriteLine($"Raised By Employee Id: {request.RequestRaisedBy}");
                Console.WriteLine($"Closed By Employee Id: {request.RequestClosedBy}");
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}
