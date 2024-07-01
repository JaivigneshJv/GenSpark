
# main_bulk.py
import json
from bulk_read import bulk_read_from_excel
from save_employee import save_to_text, save_to_excel, save_to_pdf

def main():
    filename = input("Enter the Excel filename to read: ")
    employees = bulk_read_from_excel(filename)

    print("\nEmployee Details:")
    for employee in employees:
        print(json.dumps(employee, indent=4))

    print("\nChoose file format to save:")
    print("1. Text")
    print("2. Excel")
    print("3. PDF")

    choice = input("Enter choice (1/2/3): ")

    for idx, employee in enumerate(employees):
        if choice == '1':
            save_to_text(employee, f"employee_{idx+1}.txt")
        elif choice == '2':
            save_to_excel(employee, f"employee_{idx+1}.xlsx")
        elif choice == '3':
            save_to_pdf(employee, f"employee_{idx+1}.pdf")
        else:
            print("Invalid choice")
            break

if __name__ == "__main__":
    main()
