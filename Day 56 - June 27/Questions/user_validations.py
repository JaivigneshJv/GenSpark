# print_details_with_validation.py

def validate_name(name):
    return name.isalpha()

def validate_age(age):
    return age.isdigit() and 0 < int(age) < 120

def validate_dob(dob):
    from datetime import datetime
    try:
        datetime.strptime(dob, '%Y-%m-%d')
        return True
    except ValueError:
        return False

def validate_phone(phone):
    return phone.isdigit() and len(phone) == 10

name = input("Enter your name: ")
while not validate_name(name):
    name = input("Invalid name. Please enter a valid name: ")

age = input("Enter your age: ")
while not validate_age(age):
    age = input("Invalid age. Please enter a valid age: ")

dob = input("Enter your date of birth (YYYY-MM-DD): ")
while not validate_dob(dob):
    dob = input("Invalid date of birth. Please enter a valid date of birth (YYYY-MM-DD): ")

phone = input("Enter your phone number: ")
while not validate_phone(phone):
    phone = input("Invalid phone number. Please enter a valid 10-digit phone number: ")

print("\n--- Details ---")
print(f"Name: {name}")
print(f"Age: {age}")
print(f"Date of Birth: {dob}")
print(f"Phone Number: {phone}")
