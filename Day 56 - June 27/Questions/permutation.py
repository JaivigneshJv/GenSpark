from itertools import permutations

input_string = input("Enter a string: ")
perm = permutations(input_string)

result=[]
print("Permutations of the given string are:")
for p in perm:
    result.append(''.join(p))

print(result)


def permute(s, answer):
    if len(s) == 0:
        return [answer]
    
    permutations = []
    for i in range(len(s)):
        char = s[i]
        left_substr = s[0:i]
        right_substr = s[i+1:]
        rest = left_substr + right_substr
        permutations += permute(rest, answer + char)
    
    return permutations

input_string = input("Enter a string: ")
print("Permutations of the given string are:")
result = permute(input_string, "")
print(result)
