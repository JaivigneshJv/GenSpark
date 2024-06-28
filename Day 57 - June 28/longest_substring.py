def longest_unique_substtr(string):
    n = len(string)
    seen = {}
    max_len = 0
    start = 0

    for end in range(n):
        if string[end] in seen:
            start = max(start, seen[string[end]] + 1)
        seen[string[end]] = end
        max_len = max(max_len, end - start + 1)

    return max_len

input_string = input("Enter a string: ")
result = longest_unique_substtr(input_string)
print(f"Length of the longest substring without repeating characters: {result}")
