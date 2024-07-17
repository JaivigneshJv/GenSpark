# Product Details Web API

## Overview

This Web API connects to a SQL Server instance running on a Virtual Machine to fetch product details. It retrieves the product's name, price, and picture. The picture images are stored in Azure Blob Storage, and the connection string for the SQL Server is securely stored and accessed from Azure Key Vault. The API supports only the GET method.

Links 

- [Web API swagger](https://74.225.241.169:7072/swagger/index.html)
- [Product 1](https://productapigenspark.blob.core.windows.net/images/product1.jpg)
- [Product 2](https://productapigenspark.blob.core.windows.net/images/product1.jpg)



## Features

- **Fetch Product Details**: Retrieve product information including name, price, and a link to the product image.
- **Azure Blob Storage**: Product images are hosted on Azure Blob Storage.
- **Azure Key Vault Integration**: Securely fetch the SQL Server connection string from Azure Key Vault.
- **GET Method**: The API exposes a single GET endpoint to retrieve product details.

## Getting Started

### Prerequisites

- **.NET 6.0 SDK or later**: Make sure you have .NET 6.0 SDK or a later version installed. You can download it from the [.NET official website](https://dotnet.microsoft.com/download).
- **Visual Studio or VS Code**: Recommended IDEs for developing and running the project.
- **Azure Subscription**: An Azure subscription for creating and managing Azure resources like Blob Storage and Key Vault.
- **SQL Server Instance**: A SQL Server instance hosted on an Azure Virtual Machine.

### Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/your-username/product-details-api.git
   cd product-details-api
   ```

2. **Restore Dependencies**

   ```bash
   dotnet restore
   ```

3. **Configure the Application**

   - **Add Connection String to Azure Key Vault**:
     Ensure that your SQL Server connection string is stored in Azure Key Vault. The secret name should be `SqlConnectionString`.

   - **Set Up Environment Variables**:
     Set up the following environment variables with the respective values from your Azure Key Vault and Blob Storage:

     ```bash
     AZURE_KEY_VAULT_NAME=your-key-vault-name
     AZURE_BLOB_STORAGE_CONNECTION_STRING=your-blob-storage-connection-string
     ```

4. **Build and Run the Application**

   ```bash
   dotnet build
   dotnet run
   ```

   The application will be hosted at `http://localhost:5000`.

### API Endpoint

- **GET /api/products**

  Fetches the list of products with their name, price, and image URL.

  **Response**:
  ```json
    [
    {
        "id": 1,
        "name": "Product1",
        "price": 29.99,
        "imageUrl": "https://productapigenspark.blob.core.windows.net/images/product1.jpg"
    },
    {
        "id": 2,
        "name": "Product2",
        "price": 49.99,
        "imageUrl": "https://productapigenspark.blob.core.windows.net/images/product2.jpg"
    }
    ]
  ```


