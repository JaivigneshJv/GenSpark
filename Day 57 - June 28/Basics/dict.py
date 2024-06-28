# dictionaries_example.py

# Creating a dictionary
my_dict = {
    "name": "Alice",
    "age": 25,
    "city": "New York"
}

# Accessing dictionary elements
print(f"Name: {my_dict['name']}")
print(f"Age: {my_dict['age']}")

# Adding and updating elements
my_dict["email"] = "alice@example.com"
my_dict["age"] = 26
print(f"Updated Dictionary: {my_dict}")

# Removing elements
del my_dict["city"]
print(f"Dictionary after deletion: {my_dict}")

# Looping through dictionary
for key, value in my_dict.items():
    print(f"{key}: {value}")

# Checking for keys
if "email" in my_dict:
    print("Email is present in the dictionary.")
    