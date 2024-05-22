## MINI PROJECT PROGRESS

### POTENTIAL ROUTES 
### User Management Routes

1. **User Registration**
   - **POST /api/users/register**
     - Register a new user.

2. **User Login**
   - **POST /api/users/login**
     - Authenticate a user and create a token.

3. **User Logout**
   - **POST /api/users/logout**
     - Logout the authenticated user.

4. **View User Profile**
   - **GET /api/users/profile**
     - View profile details of the authenticated user.

5. **Edit User Profile**
   - **PUT /api/users/profile**
     - Update profile information (address, contact, etc.) with admin approval.

6. **Update Account Password**
   - **PUT /api/users/update-password**
     - Update passwords for accounts.

### Account Management Routes

7. **Open a New Account**
   - **POST /api/accounts**
     - Open a new account (savings, salary, etc.).

8. **View Account Details**
   - **GET /api/accounts/{accountId}**
     - View details of a specific account.

9. **Request to Close Account**
   - **POST /api/accounts/close-request/{accountId} **
     - Raise a request to close an account.

10. **List All Accounts**
    - **GET /api/accounts**
      - List all accounts for the authenticated user.

11. **Manage Account Details**
    - **PUT /api/accounts/{accountId}**
      - Update account details (transaction password, etc.).

### Transaction Management Routes

12. **Deposit Money**
    - **POST /api/transactions/deposit**
      - Deposit money into an account.

13. **Withdraw Money**
    - **POST /api/transactions/withdraw**
      - Withdraw money from an account.

14. **Transfer Money**
    - **POST /api/transactions/transfer**
      - Transfer money between accounts (Instant/NEFT/RTFS).

15. **Repay Loan**
    - **POST /api/loans/{loanId}/repay**
      - Make a repayment towards an outstanding loan.

16. **View Transaction History**
    - **GET /api/accounts/{accountId}/transactions**
      - View transaction history of an account.

### Loan Management Routes

17. **Apply for a Loan**
    - **POST /api/loans/apply**
      - Apply for a loan.

18. **View Loan Status**
    - **GET /api/loans/{loanId}/status**
      - View the status of a specific loan application.

19. **Manage Loans**
    - **GET /api/loans**
      - Track all loans applied by the user.

20. **View Loan Repayment History**
    - **GET /api/loans/{loanId}/repayments**
      - View the repayment history of a specific loan.

### Administrative Routes

21. **View All Users**
    - **GET /api/admin/users**
      - View a list of all registered users.

22. **Manage User Accounts**
    - **PUT /api/admin/users/{userId}**
      - Update user account details.
    - **DELETE /api/admin/users/{userId}**
      - Delete a user account.

23. **Assign Roles and Permissions**
    - **POST /api/admin/users/{userId}/roles**
      - Assign roles and permissions to users.

24. **View All Accounts**
    - **GET /api/admin/accounts**
      - View a list of all accounts in the system.

25. **Manage Accounts**
    - **PUT /api/admin/accounts/{accountId}**
      - Update account details.
    - **DELETE /api/admin/accounts/{accountId}**
      - Delete/close an account.

26. **View All Transactions**
    - **GET /api/admin/transactions**
      - View a list of all transactions in the system.

27. **Approve Transactions**
    - **POST /api/admin/transactions/{transactionId}/approve**
      - Approve a specific transaction (RTFS/NEFT).

28. **Approve/Deny Loan Applications**
    - **POST /api/admin/loans/{loanId}/approve**
      - Approve a loan application.
    - **POST /api/admin/loans/{loanId}/deny**
      - Deny a loan application.

29. **Manage Loan Repayments**
    - **PUT /api/admin/loans/{loanId}/repayments/{repaymentId}**
      - Mark a repayment as received, charge for late payments, etc.