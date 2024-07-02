def weirdo(num):
    if num % 2 != 0:
        return "Weird"
    else:
        if 2 <= num <= 5:
            return "Not Weird"
        elif 6 <= num <= 20:
            return "Weird"
        elif num > 20:
            return "Not Weird"


if __name__ == '__main__':
    n = int(input().strip())
    print(weirdo(n))