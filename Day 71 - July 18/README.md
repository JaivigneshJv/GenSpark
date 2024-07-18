# Azure Resource Manager (ARM) Templates

This repository contains two Azure Resource Manager (ARM) templates. The first template deploys a SQL Server virtual machine, and the second template deploys an Azure Key Vault and a secret within it.

## Prerequisites

- An Azure subscription
- Azure CLI or Azure PowerShell installed

## Template 1: Deploy SQL Server Virtual Machine

### Parameters

- `virtualMachineName`: Name of the virtual machine.
- `virtualMachineSize`: Size of the virtual machine (e.g., Standard_DS2_v2).
- `existingVirtualNetworkName`: Name of the existing virtual network.
- `existingVnetResourceGroup`: Resource group of the existing virtual network.
- `existingSubnetName`: Name of the subnet.
- `imageOffer`: Offer for the virtual machine image (e.g., sql2019-ws2022).
- `sqlSku`: SKU for SQL Server (e.g., standard-gen2).
- `adminUsername`: Admin username for the VM.
- `adminPassword`: Admin password for the VM.
- `storageWorkloadType`: SQL Server workload type (e.g., General).
- `sqlDataDisksCount`: Number of data disks for SQL Data files.
- `dataPath`: Path for SQL Data files.
- `sqlLogDisksCount`: Number of data disks for SQL Log files.
- `logPath`: Path for SQL Log files.
- `location`: Azure location for all resources.
- `secureBoot`: Secure Boot setting of the VM.
- `vTPM`: vTPM setting of the VM.

### Deployment Steps

1. Open a terminal.
2. Navigate to the directory containing the ARM template file (e.g., `sql-vm-deploy.json`).
3. Run the following command to deploy the template:

```sh
az deployment group create --resource-group <your-resource-group> --template-file sql-vm-deploy.json --parameters <parameters-file>
```

Replace `<your-resource-group>` with your Azure resource group name and `<parameters-file>` with your parameters file if you have one.

## Template 2: Deploy Azure Key Vault and Secret

### Parameters

- `keyVaultName`: Name of the key vault.
- `location`: Azure location where the key vault should be created.
- `enabledForDeployment`: Whether Azure VMs can retrieve certificates stored as secrets.
- `enabledForDiskEncryption`: Whether Azure Disk Encryption can retrieve secrets.
- `enabledForTemplateDeployment`: Whether Azure Resource Manager can retrieve secrets.
- `tenantId`: Azure Active Directory tenant ID.
- `objectId`: Object ID of a user, service principal, or security group.
- `keysPermissions`: Permissions to keys in the vault.
- `secretsPermissions`: Permissions to secrets in the vault.
- `skuName`: SKU of the key vault (standard or premium).
- `secretName`: Name of the secret to create.
- `secretValue`: Value of the secret to create.

### Deployment Steps

1. Open a terminal.
2. Navigate to the directory containing the ARM template file (e.g., `key-vault-deploy.json`).
3. Run the following command to deploy the template:

```sh
az deployment group create --resource-group <your-resource-group> --template-file key-vault-deploy.json --parameters <parameters-file>
```

Replace `<your-resource-group>` with your Azure resource group name and `<parameters-file>` with your parameters file if you have one.

