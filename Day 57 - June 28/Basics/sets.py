# sets_example.py

# Creating a set
my_set = {1, 2, 3, 4, 5}

# Adding elements to a set
my_set.add(6)
print(f"Set after adding 6: {my_set}")

# Removing elements from a set
my_set.remove(3)
print(f"Set after removing 3: {my_set}")

# Checking for elements
print(f"Is 4 in the set? {'Yes' if 4 in my_set else 'No'}")

# Set operations
another_set = {4, 5, 6, 7, 8}

# Union
union_set = my_set | another_set
print(f"Union: {union_set}")

# Intersection
intersection_set = my_set & another_set
print(f"Intersection: {intersection_set}")

# Difference
difference_set = my_set - another_set
print(f"Difference: {difference_set}")

# Symmetric Difference
symmetric_difference_set = my_set ^ another_set
print(f"Symmetric Difference: {symmetric_difference_set}")
