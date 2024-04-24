# Shopping App

## Objective
Develop a console-based shopping application to enable customers to add products to a cart, manage their cart, and checkout.

## Implementation

The system is divided into three layers:

1. **Data Access Layer (DAL)**: This layer contains repositories for `Product`, `Cart`, and `CartItems`. It interacts with the database and performs CRUD operations.

2. **Business Logic Layer (BLL)**: This layer contains the business logic of the application. It interacts with the DAL and transforms data to and from the Models.

3. **Console Application**: This is the entry point of the application. It interacts with the BLL and presents data to the user.

## Getting Started

To run this application, ensure you have .NET 6 installed on your machine. 

1. Open a terminal.
2. Navigate to the project directory.
3. Run the program using the command `dotnet run`.

## Functional Requirements

### Product Management
Maintain a comprehensive inventory of available products, including details such as product name, price, and quantity.

### Cart Management
Enable customers to add products to their cart, view their cart, update the quantity of the products in the cart, and remove products from the cart.

### Checkout
Allow customers to checkout their cart. The total cost should include the price of all the products in the cart and any additional charges or discounts.

## Business Rules

1. All purchases below 100 will be charged a shipping charge of Rs. 100.
2. If the purchase has only 3 items and has an order value of 1500, provide a 5% discount.
3. The maximum quantity of a product in the cart cannot be more than 5.

## Unit Testing

The application includes comprehensive unit tests to ensure the reliability and correctness of the system. These tests cover all the methods in the business logic layer, ensuring that each function works as expected under various conditions.

To run the unit tests, use the following command:

```bash
dotnet test