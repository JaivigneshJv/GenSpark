# string_manipulation.py

# String concatenation
str1 = "Hello"
str2 = "World"
concatenated = str1 + ", " + str2 + "!"
print(f"Concatenated String: {concatenated}")

# String slicing
sliced = concatenated[0:5]  # Extracts "Hello"
print(f"Sliced String: {sliced}")

# String formatting
formatted = f"{str1}, {str2}!"
print(f"Formatted String: {formatted}")

# String methods
print(f"Uppercase: {formatted.upper()}")
print(f"Lowercase: {formatted.lower()}")
print(f"Title Case: {formatted.title()}")
print(f"Replace 'World' with 'Python': {formatted.replace('World', 'Python')}")

# Finding substrings
substr = "World"
print(f"Index of '{substr}': {formatted.find(substr)}")
