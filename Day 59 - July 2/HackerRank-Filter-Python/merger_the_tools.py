def merge_the_tools(string, k):
    unique = []
    for i in range(0, len(string), k):
        a = ""
        for ch in string[i:i+k]:
            if ch not in a:
                a = a + ch
        unique.append(a)
    print("\n".join(unique))

if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)