# functions_example.py

# Function definition
def greet(name):
    return f"Hello, {name}!"

# Function with multiple parameters
def add(a, b):
    return a + b

# Function with default parameters
def power(base, exponent=2):
    return base ** exponent

# Function calls
print(greet("Alice"))
print(f"Sum: {add(5, 3)}")
print(f"2 raised to the power of 3: {power(2, 3)}")
print(f"3 squared: {power(3)}")
