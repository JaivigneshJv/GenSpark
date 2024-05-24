# Simple Banking System API Models

This project contains several models used in the Simple Banking System API. Below are the details of each model.

## User

Represents a user in the system. It contains properties such as `Id`, `Username`, `PasswordHash`, `PasswordSalt`, `FirstName`, `LastName`, `Email`, `Contact`, `DateOfBirth`, `CreatedDate`, `UpdatedDate`, `Role`, `IsActive`, and `Accounts`.

## TransactionType

Represents a type of transaction that can occur in the system. It contains properties such as `TransactionTypeId`, `TypeName`, `RaiseRequest`, and `Transactions`.

## Transaction

Represents a transaction that has occurred in the system. It contains properties such as `Id`, `AccountId`, `ReceiverId`, `Amount`, `TransactionTypeId`, `Timestamp`, `Description`, `IsRecurring`, `Account`, `Receiver`, and `TransactionType`.

## PendingUserProfileUpdate

Represents a pending update to a user's profile. It contains properties such as `Id`, `UserId`, `FirstName`, `LastName`, `Contact`, `RequestDate`, `IsApproved`, `IsRejected`, and `User`.

## LoanRepayment

Represents a repayment of a loan. It contains properties such as `Id`, `LoanId`, `Amount`, `PaymentDate`, and `Loan`.

## Loan

Represents a loan in the system. It contains properties such as `Id`, `AccountId`, `Amount`, `PendingAmount`, `Status`, `AppliedDate`, `TargetDate`, `RepaidDate`, `Account`, and `LoanRepayments`.

## EmailVerification

Represents an email verification request. It contains properties such as `Id`, `UserId`, `NewEmail`, `VerificationCode`, `RequestDate`, and `User`.

## Account

Represents an account in the system. It contains properties such as `Id`, `UserId`, `AccountType`, `Balance`, `TransactionPasswordHash`, `TransactionPasswordKey`, `CreatedDate`, `UpdatedDate`, `isActive`, `User`, `Transactions`, and `Loans`.


- Implemented here in [Mini Project](https://github.com/JaivigneshJv/Backend-Mini-Project-Genspark)