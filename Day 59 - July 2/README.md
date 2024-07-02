## Part A - HackerRank Python Basic Skills 

This section contains solutions to the HackerRank Python Basic Skills Verification tasks.

[Certificate](https://www.hackerrank.com/certificates/5efe846e6cb6)

### Table of Contents

1. [Python: Shopping Cart](#python-shopping-cart)
2. [Python: Dominant Cells](#python-dominant-cells)

---

### Python: Shopping Cart

The task is to implement two classes: `ShoppingCart` and `Item` according to the following requirements:

#### `Item` Class
- **Constructor**: `Item(name: str, price: int)`
  - `name`: Name of the item.
  - `price`: Price of the item.
- **Attributes**:
  - `name`: Returns the name of the item.
  - `price`: Returns the price of the item.

#### `ShoppingCart` Class
- **Constructor**: `ShoppingCart()`
- **Methods**:
  - `add(item: Item)`: Adds the given item to the cart.
  - `total() -> int`: Returns the sum of the prices of all items currently in the cart.
  - `__len__()`: Returns the number of items in the cart.

#### Constraints
- There will be at most 5 different items.
- There will be at most 500 operations to perform on the cart.

#### Implementation

```python
class Item:
    def __init__(self, name: str, price: int):
        self.name = name
        self.price = price

class ShoppingCart:
    def __init__(self):
        self.items = []

    def add(self, item: Item):
        self.items.append(item)

    def total(self) -> int:
        return sum(item.price for item in self.items)

    def __len__(self):
        return len(self.items)
```

---

### Python: Dominant Cells

This problem requires finding the number of dominant cells in a 2-dimensional grid. A cell is considered dominant if it has a strictly greater value than all of its neighbors.

#### Function Signature
```python
def numCells(grid: List[List[int]]) -> int:
```

#### Parameters
- `grid`: A 2-dimensional array of integers.

#### Returns
- `int`: The number of dominant cells in the grid.

#### Constraints
- `1 <= n, m <= 500`
- There are at least 2 cells in the grid.

#### Implementation

```python
def numCells(grid):
    res = 0
    for i in range(len(grid)):
        for k in range(len(grid[0])):
            val = grid[i][k]
            flag = 1
            for ii in range(max(0, i-1), min(len(grid), i+2)):
                for kk in range(max(0, k-1), min(len(grid[0]), k+2)):
                    if (ii, kk) != (i, k) and val <= grid[ii][kk]:
                        flag = 0
                        break
                if flag == 0:
                    break
            else:
                res += 1
    return res
```

## Part B - HackerRank Python 

### Merge the Tools!

Given a string `s` and an integer `k`, this function splits the string into `k`-sized substrings and processes each substring to remove any duplicate characters while maintaining the order of their first occurrence.

#### Function Signature
```python
def merge_the_tools(string: str, k: int) -> None:
```

#### Parameters
- `string` (str): The string to analyze.
- `k` (int): The size of substrings to analyze.

#### Description
1. Split `string` into `k`-sized substrings.
2. For each substring, create a new string by removing any duplicate characters while preserving the order of their first occurrence.
3. Print each resulting substring on a new line.

#### Example

##### Input
```
AABCAAADA
3
```

##### Output
```
AB
CA
AD
```

#### Explanation
- Split the string into three substrings of length 3: 'AAB', 'CAA', 'ADA'.
- For 'AAB', the resulting string after removing duplicates is 'AB'.
- For 'CAA', the resulting string after removing duplicates is 'CA'.
- For 'ADA', the resulting string after removing duplicates is 'AD'.

#### Constraints
- \(1 \leq \text{length of } s \leq 10^4\)
- It is guaranteed that \( k \) is a factor of the length of `s`.

#### Implementation

```python
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
```
Here's the documentation for the third problem in Part B:

---

### Shoe Shop Earnings

In this problem, you will calculate the total earnings of a shoe shop based on customer purchases.

#### Functionality
- The `collections.Counter` tool is used to count the occurrences of elements in a list. It is a container that stores elements as dictionary keys, and their counts are stored as dictionary values.

#### Example

```python
from collections import Counter

myList = [1, 1, 2, 3, 4, 5, 3, 2, 3, 4, 2, 1, 2, 3]
print(Counter(myList))
```

Output:
```
Counter({2: 4, 3: 4, 1: 3, 4: 2, 5: 1})
```

#### Task
- You will be given the number of shoes in the shop and a list of shoe sizes.
- You will then be given the number of customers and for each customer, the desired shoe size and the price they are willing to pay.
- Your task is to compute how much money the shop owner earned.

#### Example

##### Input
```
10
2 3 4 5 6 8 7 6 5 18
6
6 55
6 45
6 55
4 40
18 60
10 50
```

##### Output
```
200
```

#### Explanation
- Customer 1: Purchased size 6 shoe for $55.
- Customer 2: Purchased size 6 shoe for $45.
- Customer 3: Size 6 no longer available, so no purchase.
- Customer 4: Purchased size 4 shoe for $40.
- Customer 5: Purchased size 18 shoe for $60.
- Customer 6: Size 10 not available, so no purchase.
- Total money earned = $200

#### Input Format
- The first line contains the number of shoes, `x`.
- The second line contains the space-separated list of all the shoe sizes in the shop.
- The third line contains the number of customers, `n`.
- The next `n` lines contain the space-separated values of the desired shoe size and the price of the shoe.

#### Constraints
- \(0 < x < 10^3\)
- \(0 < n \leq 10^3\)
- \(0 < \text{shoe size} < 100\)
- \(0 < \text{price} \leq 10^3\)

#### Output Format
Print the amount of money earned by the shop owner.

#### Implementation

```python
from collections import Counter

def calculate_earnings(x, shoe_sizes, n, customers):
    # Create a Counter for shoe sizes
    shoe_counter = Counter(shoe_sizes)
    earned_money = 0

    # Process each customer
    for size, price in customers:
        if shoe_counter[size] > 0:
            earned_money += price
            shoe_counter[size] -= 1
    
    return earned_money

if __name__ == '__main__':
    x = int(input().strip())
    shoe_sizes = list(map(int, input().strip().split()))
    n = int(input().strip())
    customers = [tuple(map(int, input().strip().split())) for _ in range(n)]
    
    print(calculate_earnings(x, shoe_sizes, n, customers))
```


---

### Conditional Actions Based on an Integer

In this problem, you will determine whether a given integer is "Weird" or "Not Weird" based on specific conditions.

#### Functionality
- Perform the following conditional actions based on the value of the integer `n`:
  - If `n` is odd, print "Weird".
  - If `n` is even and in the inclusive range of 2 to 5, print "Not Weird".
  - If `n` is even and in the inclusive range of 6 to 20, print "Weird".
  - If `n` is even and greater than 20, print "Not Weird".

#### Example

##### Input
```
3
```

##### Output
```
Weird
```

#### Explanation
- Since 3 is odd, it is considered "Weird".

##### Input
```
24
```

##### Output
```
Not Weird
```

#### Explanation
- Since 24 is even and greater than 20, it is considered "Not Weird".

#### Input Format
- A single line containing a positive integer `n`.

#### Constraints
- \( 1 \leq n \leq 100 \)

#### Output Format
- Print "Weird" if the number is weird. Otherwise, print "Not Weird".

#### Implementation

```python
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
```

---

### Arithmetic Operations with Two Integers

In this problem, you will read two integers from the standard input and perform three arithmetic operations: addition, subtraction, and multiplication. The results of these operations will be printed each on a new line.

#### Functionality
- Read two integers, `a` and `b`.
- Print three lines:
  1. The sum of `a` and `b`.
  2. The difference when `b` is subtracted from `a`.
  3. The product of `a` and `b`.

#### Example

##### Input
```
3
2
```

##### Output
```
5
1
6
```

#### Explanation
- The sum of `3` and `2` is `5`.
- The difference when `2` is subtracted from `3` is `1`.
- The product of `3` and `2` is `6`.

#### Input Format
- The first line contains the first integer, `a`.
- The second line contains the second integer, `b`.

#### Constraints
- \( 1 \leq a, b \leq 10^6 \)

#### Output Format
- Print three lines:
  1. The sum of `a` and `b`.
  2. The difference when `b` is subtracted from `a`.
  3. The product of `a` and `b`.

#### Implementation

```python
if __name__ == '__main__':
    a = int(input())
    b = int(input())

    print(a + b)
    print(a - b)
    print(a * b)
```

---

### Integer and Float Division

In this task, you will read two integers from the standard input and perform two types of division operations: integer division and float division. You will then print the results on separate lines.

#### Functionality
- Read two integers, `a` and `b`.
- Print two lines:
  1. The result of integer division, `a // b`.
  2. The result of float division, `a / b`.

#### Example

##### Input
```
4
3
```

##### Output
```
1
1.3333333333333333
```

#### Explanation
- The integer division of `4` by `3` is `1` (as it discards the remainder).
- The float division of `4` by `3` is approximately `1.3333333333333333`.

#### Input Format
- The first line contains the first integer, `a`.
- The second line contains the second integer, `b`.

#### Constraints
- \( 1 \leq a, b \leq 10^6 \)
- \( b \neq 0 \) (since division by zero is undefined)

#### Output Format
- Print the result of integer division on the first line.
- Print the result of float division on the second line.

#### Implementation

```python
if __name__ == '__main__':
    a = int(input())
    b = int(input())

    print(a // b)
    print(a / b)
```


---

### Leap Year Determination

In this task, you will determine whether a given year is a leap year based on specific conditions defined by the Gregorian calendar.

#### Functionality
- Check if a given year is a leap year.
- A leap year is determined by the following conditions:
  1. The year must be evenly divisible by 4.
  2. If the year is also divisible by 100, it must also be divisible by 400 to be a leap year.

#### Example

##### Input
```
1990
```

##### Output
```
False
```

##### Explanation
- 1990 is not a multiple of 4, so it is not a leap year.

#### Input Format
- A single integer `year` representing the year to be tested.

#### Constraints
- \( 1900 \leq \text{year} \leq 10^5 \)

#### Output Format
- The function must return `True` if the year is a leap year, otherwise `False`.

#### Implementation

```python
def is_leap(year):
    return year % 4 == 0 and (year % 100 != 0 or year % 400 == 0)

year = int(input())
print(is_leap(year))
```

#### Explanation of the Code
- The `is_leap` function checks if the year is divisible by 4 but not by 100, unless it is also divisible by 400.
- The `print` statement outputs the result of the `is_leap` function.

---

### 3D Coordinates List Comprehension

You are given dimensions of a cuboid and a value for `n`. The goal is to generate a list of all possible 3D coordinates where the sum of the coordinates is not equal to `n`. You should achieve this using list comprehensions.

#### Task Description

Given integers `x`, `y`, `z`, and `n`, you need to find all possible coordinates `[i, j, k]` where:
- \( 0 \leq i \leq x \)
- \( 0 \leq j \leq y \)
- \( 0 \leq k \leq z \)

The list of coordinates should be such that the sum \( i + j + k \) does not equal `n`.

#### Example

For the input:
```
1
1
1
2
```

All possible coordinates are:
```
[0, 0, 0], [0, 0, 1], [0, 1, 0], [1, 0, 0], [1, 1, 1], [0, 1, 1], [1, 0, 1], [1, 1, 0]
```

From these, the coordinates where \( i + j + k \neq 2 \) are:
```
[[0, 0, 0], [0, 0, 1], [0, 1, 0], [1, 0, 0], [1, 1, 1]]
```

#### Input Format

- Four integers `x`, `y`, `z`, and `n` are provided, each on a separate line.

#### Constraints

- \( 0 \leq x, y, z \leq 10 \)
- \( 0 \leq n \leq 30 \)

#### Output Format

- Print a list of lists where each list is a coordinate `[i, j, k]` such that \( i + j + k \neq n \).

#### Implementation

You can solve this problem using a list comprehension to generate the desired list of coordinates. Here’s how you can do it:

```python
if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())
    
    # List comprehension to generate all coordinates where the sum of i, j, k is not equal to n
    combined = [[i, j, k] for i in range(x+1) for j in range(y+1) for k in range(z+1) if (i + j + k) != n]
    
    print(combined)
```

#### Explanation of the Code

- **Input Reading:**
  ```python
  x = int(input())
  y = int(input())
  z = int(input())
  n = int(input())
  ```
  Reads four integers from the input.

- **List Comprehension:**
  ```python
  combined = [[i, j, k] for i in range(x+1) for j in range(y+1) for k in range(z+1) if (i + j + k) != n]
  ```
  Generates a list of coordinates `[i, j, k]` for all possible values of `i`, `j`, and `k` where the sum of `i + j + k` is not equal to `n`.

- **Print the Result:**
  ```python
  print(combined)
  ```
  Outputs the final list of coordinates.

#### Sample Inputs and Outputs

Here are a few sample inputs and outputs:

| Sample Input | Output |
|--------------|--------|
| `1 1 1 2`    | `[[0, 0, 0], [0, 0, 1], [0, 1, 0], [1, 0, 0], [1, 1, 1]]` |
| `2 2 2 2`    | `[[0, 0, 0], [0, 0, 1], [0, 0, 2], [0, 1, 0], [0, 1, 1], [0, 1, 2], [0, 2, 0], [0, 2, 1], [0, 2, 2], [1, 0, 0], [1, 0, 1], [1, 0, 2], [1, 1, 0], [1, 1, 1], [1, 1, 2], [1, 2, 0], [1, 2, 1], [1, 2, 2], [2, 0, 0], [2, 0, 1], [2, 0, 2], [2, 1, 0], [2, 1, 1], [2, 1, 2], [2, 2, 0], [2, 2, 1], [2, 2, 2]]` |
