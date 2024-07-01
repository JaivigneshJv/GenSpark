import re
from datetime import datetime

def validate_name(name):
    return bool(re.match(r'^[A-Za-z ]+$', name))

def validate_dob(dob):
    try:
        datetime.strptime(dob, '%Y-%m-%d')
        return True
    except ValueError:
        return False

def validate_phone(phone):
    return bool(re.match(r'^\d{10}$', phone))

def validate_email(email):
    return bool(re.match(r'^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$', email))

def calculate_age(dob):
    birth_date = datetime.strptime(dob, '%Y-%m-%d')
    today = datetime.today()
    age = today.year - birth_date.year - ((today.month, today.day) < (birth_date.month, birth_date.day))
    return age

def get_employee_details():
    name = input("Enter name: ")
    while not validate_name(name):
        print("Invalid name. Please enter again.")
        name = input("Enter name: ")

    dob = input("Enter date of birth (YYYY-MM-DD): ")
    while not validate_dob(dob):
        print("Invalid date of birth. Please enter again.")
        dob = input("Enter date of birth (YYYY-MM-DD): ")

    phone = input("Enter phone number (10 digits): ")
    while not validate_phone(phone):
        print("Invalid phone number. Please enter again.")
        phone = input("Enter phone number (10 digits): ")

    email = input("Enter email: ")
    while not validate_email(email):
        print("Invalid email. Please enter again.")
        email = input("Enter email: ")

    age = calculate_age(dob)

    return {
        'Name': name,
        'DOB': dob,
        'Phone': phone,
        'Email': email,
        'Age': age
    }
