import os
import datetime
from employee_details import get_employee_details
from save_employee import save_to_text, save_to_excel, save_to_pdf

def main():
    employee = get_employee_details()
    print("\nEmployee Details:")
    for key, value in employee.items():
        print(f"{key}: {value}")
    
    print("\nChoose file format to save:")
    print("1. Text")
    print("2. Excel")
    print("3. PDF")

    choice = input("Enter choice (1/2/3): ")

    if choice == '1':
        filename = "employee_details.txt"
        save_to_text(employee, filename)
    elif choice == '2':
        filename = "employee_details.xlsx"
        save_to_excel(employee, filename)
    elif choice == '3':
        filename = "employee_details.pdf"
        save_to_pdf(employee, filename)
    else:
        print("Invalid choice")

    if os.path.exists(filename):
        print(f"\nDetails saved to {filename}")

if __name__ == "__main__":
    main()
