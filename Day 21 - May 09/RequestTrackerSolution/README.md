# Request Tracker Application

The Request Tracker Application is a simple command-line tool built using C# and Entity Framework Core that allows users to manage requests within an organization. Users can log in, register, and perform CRUD operations on requests.

## Features

- User Authentication: Users can log in with their employee ID and password.
- Registration: New users can register with their employee ID and password.
- Request Management: Users can add, update, delete, view details of a specific request, and view all requests in the system.

## Getting Started

To get started with the Request Tracker Application, follow these steps:

1. Clone the Repository: Clone this repository to your local machine.

2. Open Solution: Navigate to the cloned repository and open the solution file (RequestTracker.sln) in Visual Studio or any other C# IDE.

3. Database Setup: The application uses Entity Framework Core with Code-First approach. Ensure you have SQL Server installed on your machine. Update the connection string in appsettings.json file in the RequestTrackerFEAPP project to point to your SQL Server instance.

    ```json
    "ConnectionStrings": {
         "dbEmployeeTrackerCF": "Server=localhost;Database=RequestTrackerDB;Trusted_Connection=True;"
    }
    ```

4. Run PMC Commands: Open Package Manager Console (PMC) and run the following commands to apply migrations and update the database schema:

    ```bash
    Add-Migration init
    Update-Database
    ```

5. Run the Application: Build and run the application. This will automatically create the database based on the model classes and seed some initial data.

6. Use the Application: Follow the on-screen prompts to navigate through the application. You can log in, register, and manage requests as needed.

## Dependencies

- Entity Framework Core: Entity Framework Core is used as an Object-Relational Mapping (ORM) framework to interact with the database.
- Microsoft.EntityFrameworkCore.Design: This package provides design-time support for Entity Framework Core tools.
- Microsoft.Extensions.Configuration.Json: This package is used to read configuration data from JSON files.