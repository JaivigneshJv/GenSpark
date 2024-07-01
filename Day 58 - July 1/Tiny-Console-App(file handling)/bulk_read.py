import pandas as pd
from employee_details import validate_name, validate_dob, validate_phone, validate_email, calculate_age

def bulk_read_from_excel(filename):
    df = pd.read_excel(filename)
    employees = []
    for index, row in df.iterrows():
        name = row['Name']
        dob = row['DOB']
        phone = row['Phone']
        email = row['Email']
        print(name, dob, phone, email)
        if validate_name(name) and validate_dob(dob) and validate_phone(str(phone)) and validate_email(email):
            age = calculate_age(dob)
            employee = {
                'Name': name,
                'DOB': dob,
                'Phone': phone,
                'Email': email,
                'Age': age
            }
            employees.append(employee)
    return employees
