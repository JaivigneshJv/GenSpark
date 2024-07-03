count = int(input())
array = []
for i in range(count):
    command , *key = input().split()
    item = list(map(int,key))
    if command == "insert":
        array.insert(item[0],item[1])
    elif command == "print":
        print(array)
    elif command == "remove":
        array.remove(item[0])
    elif command == "append":
        array.append(item[0])
    elif command == "sort":
        array.sort()
    elif command == "pop":
        array.pop()
    elif command == "reverse":
        array.reverse()
