# PizzaOrderingAPI 

## Overview

The `PizzaOrderingAPI` is designed to manage user registrations, logins, and pizza orders with added functionality for role-based access control. This README summarizes the recent changes that include role-based routes, JWT token handling with cookies, and new user roles.

## Recent Changes

### 1. Role-Based Access Control

#### Summary:
- Implemented roles for users to distinguish between regular users and admin users.
- Added new routes for managing user roles and accessing/administering pizza-related data based on user roles.

#### Modifications:
- **User Roles**: Introduced a new `Role` field for users, which can be either `Admin` or `User`.
- **Admin Access**: Only users with the `Admin` role can add or update pizza information.

### 2. JWT Authentication with Cookies

#### Summary:
- Updated the authentication mechanism to store JWT tokens in cookies for easier and secure access.

#### Modifications:
- **Token Storage**: Upon successful login, the JWT token is stored in an HTTP-only cookie.
- **Token Retrieval**: The token is automatically retrieved from the cookie for subsequent authenticated requests.

Modified from [PizzaOrdering](./PizzaOrderingSolution/)



# Employee Request Tracker 

## Overview
The `Employee Request Tracker` is an API designed to manage employee requests and track their status. This README provides an overview of the API's functionality and key endpoints. [Picked Up from Gayat09](https://github.com/gayat19/FSD09Apr2024/tree/master/Day24)


## Security
The API uses JWT (JSON Web Token) for authentication and authorization. The `TokenService` class is responsible for generating and validating JWT tokens.

## API Endpoints
Here are some of the key endpoints of the API:

### Authentication
- **POST /api/auth/login**: Authenticate a user and return a JWT token.
- **POST /api/auth/register**: Register a new user.

### Employees
- **GET /api/employees**: Get all employees (Admin only).
- **GET /api/employees/{id}**: Get an employee by ID.
- **POST /api/employees**: Create a new employee (Admin only).
- **PUT /api/employees/{id}**: Update an employee (Admin only).
- **DELETE /api/employees/{id}**: Delete an employee (Admin only).

### Requests
- **GET /api/requests**: Get all requests (Admin only).
- **GET /api/requests/{id}**: Get a request by ID.
- **POST /api/requests**: Create a new request (Employee only).
- **PUT /api/requests/{id}**: Update a request (Employee only).
- **DELETE /api/requests/{id}**: Delete a request (Admin/Manager only).

## Key Files and Directories
- **Program.cs**: Entry point of the application.
- **appsettings.json**: Configuration settings.
- **Controllers**:
    - **EmployeeController.cs**: Manages employee-related operations.
    - **RequestController.cs**: Manages request-related operations.
    - **AuthController.cs**: Handles authentication and authorization.
- **Models**:
    - **Employee.cs**: Represents an employee.
    - **Request.cs**: Represents a request.
- **Repositories**:
    - **EmployeeRepository.cs**: Data access logic for employees.
    - **RequestRepository.cs**: Data access logic for requests.
    - **UserRepository.cs**: Data access logic for users.
- **Services**:
    - **EmployeeService.cs**: Business logic for employee operations.
    - **RequestService.cs**: Business logic for request operations.
    - **TokenService.cs**: Handles JWT token generation and validation.
    - **UserService.cs**: Business logic for user operations.
