# tuples_example.py

# Creating a tuple
my_tuple = (1, 2, 3, "Hello", 4.5)

# Accessing tuple elements
print(f"First element: {my_tuple[0]}")
print(f"Last element: {my_tuple[-1]}")

# Slicing a tuple
print(f"Slice [1:4]: {my_tuple[1:4]}")

# Tuple concatenation
another_tuple = (6, 7, 8)
concatenated_tuple = my_tuple + another_tuple
print(f"Concatenated Tuple: {concatenated_tuple}")

# Tuple methods
print(f"Count of 3 in tuple: {my_tuple.count(3)}")
print(f"Index of 'Hello': {my_tuple.index('Hello')}")
