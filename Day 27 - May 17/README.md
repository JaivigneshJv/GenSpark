


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

