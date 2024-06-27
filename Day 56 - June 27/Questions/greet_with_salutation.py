name = input("Enter your name: ")
gender = input("Enter your gender (M/F): ")

salutation = "Mr." if gender.upper() == "M" else "Ms."
print("Hello, "+salutation + " " +  name+"!")