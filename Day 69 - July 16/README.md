# Azure Blob Storage Image Gallery

This project demonstrates how to create a simple image gallery using Azure Blob Storage. It allows users to upload images, which are then stored in Azure Blob Storage. The images and their metadata (name, size, and upload date) are displayed in a gallery format.

## Prerequisites

- An Azure account
- An Azure Storage account
- A container in your Azure Storage account

## Setup Instructions

### 1. Create an Azure Storage Account and Container

1. **Create a Storage Account**:
   - Log in to the [Azure portal](https://portal.azure.com/).
   - Click on "Create a resource" and select "Storage account".
   - Fill in the required fields and create the storage account.

2. **Create a Container**:
   - In your storage account, go to the "Containers" section.
   - Click on "+ Container" to create a new container.
   - Name your container (e.g., `images`) and set the public access level to "Private".

### 2. Configure CORS for Azure Storage

1. **Navigate to your storage account** in the Azure portal.
2. **In the left sidebar**, under "Settings", click on "CORS".
3. **Add a new CORS rule** with the following details:
   - **Allowed origins**: `*` (for testing purposes; in production, specify your domain)
   - **Allowed methods**: `GET, PUT, POST`
   - **Allowed headers**: `*`
   - **Exposed headers**: `*`
   - **Max age**: `86400` (24 hours)
4. Click on "Save" to apply the CORS rule.

### 3. Generate a SAS Token

1. **In your container**, click on "Shared access signature" in the left sidebar.
2. **Set the Permissions**:
   - Read (r)
   - Write (w)
   - List (l)
   - Delete (d)
   - Update (u)
3. **Set the Start and Expiry Date**:
   - Make sure the `Start` time is in the past and the `Expiry` time is set appropriately for your needs.
4. **Click on "Generate SAS and connection string"**.
5. **Copy the Blob SAS URL**.


### Additional Notes

- **Security**: For production, do not use `*` in CORS settings or expose SAS tokens publicly. Restrict CORS to specific domains and limit the SAS token scope and permissions as needed.
- **Error Handling**: Enhance error handling in the JavaScript code to better manage potential issues during image upload or JSON file updates.


Here's a README file tailored for a project that uses Azurite to emulate Azure Blob Storage for local development. It includes instructions on setting up Azurite, running the project, and key learnings from the experience.


<br>
<br>
<br>
<br>
<br>

# Azurite Image Gallery

This project demonstrates a simple image gallery using Azurite, an Azure Storage emulator for local development. Users can upload images, which are stored locally in Azurite and displayed in a gallery format with metadata.

## Prerequisites

- Node.js and npm installed
- Azurite installed
- A web server (e.g., http-server) to serve the HTML file

## Setup Instructions

### 1. Install Azurite

Azurite can be installed via npm. Open your terminal and run:

```sh
npm install -g azurite
```

### 2. Start Azurite

Start Azurite to emulate Azure Blob Storage locally:

```sh
azurite --location ./azurite --silent --debug ./azurite/debug.log
```

This command starts Azurite and stores data in the `./azurite` directory.

### 3. Create a Container

Use Azure Storage Explorer or any tool that supports Azure Storage to create a container in Azurite. Here’s how to do it using Azure Storage Explorer:

1. Open Azure Storage Explorer.
2. Connect to Azurite by selecting "Attach to a local emulator" and provide the endpoint URL (default: `http://127.0.0.1:10000/devstoreaccount1`).
3. Create a new blob container (e.g., `images`).

### 4. Configure CORS for Azurite

Azurite supports CORS settings similar to Azure Storage. Configure CORS in Azurite by creating a `cors.json` file in the Azurite working directory with the following content:

```json
[
    {
        "AllowedOrigins": ["*"],
        "AllowedMethods": ["GET", "PUT", "POST"],
        "AllowedHeaders": ["*"],
        "ExposedHeaders": ["*"],
        "MaxAgeInSeconds": 86400
    }
]
```

### 5. Generate a SAS Token

Azurite supports Shared Access Signatures (SAS) similar to Azure Storage. Use the `azure-storage` npm package or Azure Storage Explorer to generate a SAS token with appropriate permissions (`Read`, `Write`, `List`, `Delete`, `Update`).

Similar to the app above