from collections import Counter

if __name__ == '__main__':
    x = int(input().rstrip())
    shoe_sizes = Counter(list(map(int, input().rstrip().split())))
    n = int(input().rstrip())
    earned_money = 0
    for i in range(n):
        sz, price = list(map(int, input().rstrip().split()))
        if sz not in shoe_sizes.keys() or shoe_sizes.get(sz) == 0:
            continue
        shoe_sizes[sz] -= 1
        earned_money += price
    print(earned_money)