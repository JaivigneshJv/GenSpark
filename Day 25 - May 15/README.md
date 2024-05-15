# Pizza Ordering API

This is a RESTful API for a pizza ordering system built with ASP.NET Core and Entity Framework Core. The API allows users to register, login, and place orders for pizzas. It also provides endpoints to manage users, pizzas, and orders.

## Features

- User registration and Login
- CRUD operations for users and pizzas
- Ordering pizzas

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger for API documentation

## API Endpoints

### User Endpoints

<details>
<summary>Endpoints</summary>

- **POST /register**: Register a new user
- **POST /login**: Login a user
- **GET /users/{id}**: Get a user by ID
- **GET /users**: Get all users
- **PUT /api/users/{id}**: Update a user


</details>

### Pizza Endpoints

<details>
<summary>Endpoints</summary>

- **GET /PizzasInStock**: Get available pizzas
- **POST /api/pizzas**: Create a new pizza
- **GET /api/pizzas/{id}**: Get a pizza by ID
- **GET /api/pizzas/name/{name}**: Get a pizza by name
- **GET /api/pizzas**: Get all pizzas
- **PUT /api/pizzas/{id}**: Update a pizza

</details>

### Order Endpoints

<details>
<summary>Endpoints</summary>

- **POST /api/orders**: Create a new order

</details>

## DEMO
<details>
<summary>Login / Register</summary>

![](./Assets/ezgif-3-c6c88f6ad4.gif)


</details>


<details>
<summary>GetInStock</summary>

![](./Assets/ezgif-3-a0df8e5af8.gif)


</details>



