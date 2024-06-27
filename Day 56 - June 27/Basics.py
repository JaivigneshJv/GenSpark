# Variables and Basic Syntax Example
x = 5
y = 10
z = x + y

print("Variables and Basic Syntax Example:")
print("x = " + str(x))
print("y = " + str(y))
print("x + y = " + str(z))
print()

# Expressions Example
a = 2 * (3 + 5)
b = 10 / 2
c = 2 ** 3  # Exponentiation

print("Expressions Example:")
print("2 * (3 + 5) = " + str(a))
print("10 / 2 = " + str(b))
print("2 ** 3 = " + str(c))
print()

# Comments Example
print("Comments Example:")
# This is a single-line comment
print("This line is executed")

"""
This is a multi-line comment
None of the lines in this block will be executed
"""
print("This line is also executed")
print()

# String Manipulation Example
print("String Manipulation Example:")
greeting = "Hello"
name = "World"
message = greeting + ", " + name + "!"
print(message)
print("Length of message: " + str(len(message)))
print("Uppercase: " + message.upper())
print()

# Type Casting Example
print("Type Casting Example:")
num_str = "123"
num_int = int(num_str)
num_float = float(num_str)

print("String: " + num_str)
print("Integer: " + str(num_int))
print("Float: " + str(num_float))
print()


print("Detailed Data Types Example:")

# Integer
integer = 42
print("Integer: " + str(integer) + " (Type: " + str(type(integer)) + ")")

# Float
floating_point = 3.14159
print("Float: " + str(floating_point) + " (Type: " + str(type(floating_point)) + ")")

# String
string = "Hello, Python!"
print("String: '" + string + "' (Type: " + str(type(string)) + ")")

# Boolean
boolean = True
print("Boolean: " + str(boolean) + " (Type: " + str(type(boolean)) + ")")

# List
my_list = [1, 2, 3, 4, 5]
print("List: " + str(my_list) + " (Type: " + str(type(my_list)) + ")")

# Tuple
my_tuple = (1, 2, 3)
print("Tuple: " + str(my_tuple) + " (Type: " + str(type(my_tuple)) + ")")

# Dictionary
my_dict = {"name": "Alice", "age": 25}
print("Dictionary: " + str(my_dict) + " (Type: " + str(type(my_dict)) + ")")

# Set
my_set = {1, 2, 3, 4, 5}
print("Set: " + str(my_set) + " (Type: " + str(type(my_set)) + ")")
print()


print("More on Operators Example:")

# Arithmetic Operators
a = 10
b = 3

print("Addition: " + str(a + b))
print("Subtraction: " + str(a - b))
print("Multiplication: " + str(a * b))
print("Division: " + str(a / b))
print("Modulus: " + str(a % b))
print("Exponentiation: " + str(a ** b))
print("Floor Division: " + str(a // b))
print()

# Comparison Operators
print("Equal: " + str(a == b))
print("Not Equal: " + str(a != b))
print("Greater Than: " + str(a > b))
print("Less Than: " + str(a < b))
print("Greater Than or Equal To: " + str(a >= b))
print("Less Than or Equal To: " + str(a <= b))
print()

# Logical Operators
x = True
y = False

print("Logical AND: " + str(x and y))
print("Logical OR: " + str(x or y))
print("Logical NOT: " + str(not x))
print()

# Assignment Operators
c = 5
c += 3  # c = c + 3
print("Assignment (+=): " + str(c))

c *= 2  # c = c * 2
print("Assignment (*=): " + str(c))
print()


print("More on Strings Example:")

# String concatenation
str1 = "Hello"
str2 = "World"
concatenated = str1 + ", " + str2 + "!"
print("Concatenated String: " + concatenated)

# String slicing
sliced = concatenated[0:5]  # Extracts "Hello"
print("Sliced String: " + sliced)

# String formatting
formatted = str1 + ", " + str2 + "!"
print("Formatted String: " + formatted)

# String methods
print("Uppercase: " + formatted.upper())
print("Lowercase: " + formatted.lower())
print("Title Case: " + formatted.title())
print("Replace 'World' with 'Python': " + formatted.replace('World', 'Python'))
print()



# Example of conditional statements
num = 10

if num > 0:
    print("Number is positive")
elif num == 0:
    print("Number is zero")
else:
    print("Number is negative")


# Example of a for loop
for i in range(5):
    print(f"For Loop Iteration: {i}")

# Example of a while loop
count = 0
while count < 5:
    print(f"While Loop Iteration: {count}")
    count += 1


# Example of a method (function)
def greet(name):
    return f"Hello, {name}!"

print(greet("Alice"))

# Example of a function with parameters
def add(a, b):
    return a + b

print(f"Sum: {add(5, 3)}")

# Example of a function that returns a value
def multiply(a, b):
    return a * b

result = multiply(4, 5)
print(f"Product: {result}")

# Example of a list and indexing
fruits = ["apple", "banana", "cherry"]
print(f"First fruit: {fruits[0]}")
print(f"Second fruit: {fruits[1]}")
print(f"Third fruit: {fruits[2]}")
