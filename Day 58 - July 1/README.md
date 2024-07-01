# Python Learnings

## Overview

This document provides an overview of the Python learning concepts and an application developed to manage employee details. The learning concepts cover the basics of Python programming, including object-oriented programming, exception handling, file handling, and module usage. The application demonstrates the practical implementation of these concepts.

## Learning Topics

### 1. Python Class

- **Definition**: A blueprint for creating objects (a particular data structure).
- **Purpose**: Encapsulates data and functions that manipulate the data.

### 2. Inheritance in Python

- **Definition**: A mechanism where a new class inherits attributes and methods from an existing class.
- **Purpose**: Promotes code reuse and establishes a relationship between different classes.

### 3. Polymorphism in Python

- **Definition**: The ability to present the same interface for different data types.
- **Purpose**: Allows functions or methods to use entities of different types at different times.

### 4. Modules in Python

- **Definition**: A file containing Python code that can define functions, classes, and variables.
- **Purpose**: Organizes code into manageable, reusable components.

### 5. Exception Handling (Try Except)

- **Definition**: Mechanism to handle runtime errors in a program.
- **Purpose**: Prevents program crashes by providing a way to manage errors gracefully.

### 6. File Handling - Read and Write

- **Definition**: The process of opening, reading, writing, and closing files.
- **Purpose**: Allows data persistence by saving data to files and retrieving it later.

## Employee Management Application

### Overview

The application takes employee details (Name, DOB, Phone, and E-Mail) from the console, validates the inputs, calculates the age based on the DOB, and provides options to store the details in a file (text, Excel, or PDF). It also includes an optional feature for bulk reading from an Excel file.

### Features

- **Input Validation**: Ensures that the entered details meet the required format and constraints.
- **Age Calculation**: Automatically calculates the age based on the DOB.
- **File Storage Options**: Allows saving employee details in different file formats (text, Excel, PDF).
- **Bulk Read**: Reads multiple employee details from an Excel file and stores them in a list.

### Steps to Use the Application

1. **Run the Application**: Execute the main script to start the application.
2. **Enter Employee Details**: Provide the required details when prompted.
3. **Choose File Format**: Select the desired file format for saving the details.
4. **Save Details**: The application saves the validated details in the chosen format.
5. **Bulk Read Option**: Use the bulk read feature to load multiple employee details from an Excel file.

### Optional Implementation

- **Bulk Read from Excel**: Load multiple employee details from an Excel file and store them in a list for further processing or saving in other formats.

## Additional Resources

### Packages Imported

- **json**: For handling JSON data.
- **xlsxwriter**: For creating and writing Excel files.
- **openpyxl**: For reading and writing Excel files.
- **fpdf**: For creating PDF files.
- **pandas**: For data manipulation and analysis (especially with Excel files).

## Installation

Make sure you have the required libraries installed. Use the following commands to install the necessary packages:

```sh
pip install xlsxwriter openpyxl fpdf pandas
```

