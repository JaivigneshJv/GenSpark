- [**Shoe Shop Owner Earnings**](#shoe-shop-owner-earnings)
  - [Task](#task)
  - [Input Format](#input-format)
  - [Constraints](#constraints)
  - [Output Format](#output-format)
  - [Example](#example)
- [**Company Logo Based on Character Frequency**](#company-logo-based-on-character-frequency)
  - [Task](#task-1)
  - [Input Format](#input-format-1)
  - [Constraints](#constraints-1)
  - [Output Format](#output-format-1)
  - [Example](#example-1)
- [**Conditional Actions Based on Integer**](#conditional-actions-based-on-integer)
  - [Task](#task-2)
  - [Input Format](#input-format-2)
  - [Constraints](#constraints-2)
  - [Output Format](#output-format-2)
  - [Example](#example-2)
- [**Basic Arithmetic Operations**](#basic-arithmetic-operations)
  - [Task](#task-3)
  - [Input Format](#input-format-3)
  - [Output Format](#output-format-3)
  - [Example](#example-3)
- [**Division Operations**](#division-operations)
  - [Task](#task-4)
  - [Input Format](#input-format-4)
  - [Output Format](#output-format-4)
  - [Example](#example-4)
- [**Squares of Non-Negative Integers**](#squares-of-non-negative-integers)
  - [Task](#task-5)
  - [Input Format](#input-format-5)
  - [Output Format](#output-format-5)
  - [Example](#example-5)
- [**Leap Year Checker**](#leap-year-checker)
  - [Task](#task-6)
  - [Input Format](#input-format-6)
  - [Output Format](#output-format-6)
  - [Example](#example-6)
- [**Concatenation of Integers**](#concatenation-of-integers)
  - [Task](#task-7)
  - [Input Format](#input-format-7)
  - [Output Format](#output-format-7)
  - [Example](#example-7)
- [**Cuboid Coordinates**](#cuboid-coordinates)
  - [Task](#task-8)
  - [Input Format](#input-format-8)
  - [Output Format](#output-format-8)
  - [Example](#example-8)
- [**List of Student Names with Second Lowest Grade**](#list-of-student-names-with-second-lowest-grade)
  - [Task](#task-9)
  - [Input Format](#input-format-9)
  - [Output Format](#output-format-9)
  - [Example](#example-9)
- [**Average of Student Marks**](#average-of-student-marks)
  - [Task](#task-10)
  - [Input Format](#input-format-10)
  - [Output Format](#output-format-10)
  - [Example](#example-10)
- [**List Operations Based on Commands**](#list-operations-based-on-commands)
  - [Task](#task-11)
  - [Input Format](#input-format-11)
  - [Output Format](#output-format-11)
  - [Example](#example-11)
- [**Hashing a Tuple**](#hashing-a-tuple)
  - [Task](#task-12)
  - [Input Format](#input-format-12)
  - [Output Format](#output-format-12)
  - [Example](#example-12)
- [**Case Swapping in a String**](#case-swapping-in-a-string)
  - [Task](#task-13)
  - [Input Format](#input-format-13)
  - [Output Format](#output-format-13)
  - [Example](#example-13)
- [**Split and Join a String**](#split-and-join-a-string)
  - [Task](#task-14)
  - [Input Format](#input-format-14)
  - [Output Format](#output-format-14)
  - [Example](#example-14)
- [Docker Learnings](#docker-learnings)
  - [What is Docker?](#what-is-docker)
  - [Creating a Container for Node.js](#creating-a-container-for-nodejs)


### **Shoe Shop Owner Earnings**

#### Task
Given the number of shoes in a shop and a list of shoe sizes, compute the total money earned from selling shoes to customers who pay a specified amount if they get their desired shoe size.

#### Input Format
- The first line contains an integer, the number of shoes.
- The second line contains the space-separated list of shoe sizes in the shop.
- The third line contains an integer, the number of customers.
- The next lines contain the desired shoe size and the price the customer is willing to pay.

#### Constraints
- 0 < Number of shoes ≤ 10^3
- 0 < Size of shoes ≤ 10^3
- 0 < Number of customers ≤ 10^3
- 0 < Price of shoes ≤ 10^3

#### Output Format
Print the total money earned.

#### Example
**Input:**
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

**Output:**
```
200
```

```python
from collections import Counter

if __name__ == '__main__':
    x = int(input().rstrip())
    shoe_sizes = Counter(list(map(int, input().rstrip().split())))
    n = int(input().rstrip())
    earned_money = 0
    for i in range(n):
        sz, price = list(map(int, input().rstrip().split()))
        if sz in shoe_sizes and shoe_sizes[sz] > 0:
            shoe_sizes[sz] -= 1
            earned_money += price
    print(earned_money)
```

###  **Company Logo Based on Character Frequency**

#### Task
Given a string representing the company name, find the top three most common characters in the string.

#### Input Format
A single line containing the string.

#### Constraints
- The string has at least 3 distinct characters.

#### Output Format
Print the three most common characters along with their occurrence count each on a separate line.

#### Example
**Input:**
```
aabbbccde
```

**Output:**
```
b 3
a 2
c 2
```

```python
from collections import Counter

if __name__ == '__main__':
    s = sorted(input())
    characters = Counter(s).most_common(3)
    
    for i in characters:
        print(f'{i[0]} {i[1]}')
```

### **Conditional Actions Based on Integer**

#### Task
Given an integer, perform conditional actions to determine if the integer is "Weird" or "Not Weird".

#### Input Format
A single line containing a positive integer.

#### Constraints
- 1 ≤ n ≤ 100

#### Output Format
Print "Weird" or "Not Weird".

#### Example
**Input:**
```
3
```

**Output:**
```
Weird
```

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

### **Basic Arithmetic Operations**

#### Task
Read two integers and print their sum, difference, and product.

#### Input Format
Two integers, each on a separate line.

#### Output Format
Print three lines: the sum, the difference, and the product of the two numbers.

#### Example
**Input:**
```
3
2
```

**Output:**
```
5
1
6
```

```python
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    print(a + b)
    print(a - b)
    print(a * b)
```

### **Division Operations**

#### Task
Read two integers and print the result of integer division and float division.

#### Input Format
Two integers, each on a separate line.

#### Output Format
Print two lines: the result of integer division and float division.

#### Example
**Input:**
```
4
3
```

**Output:**
```
1
1.3333333333333333
```

```python
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    print(a // b)
    print(a / b)
```

### **Squares of Non-Negative Integers**

#### Task
Read an integer and print the squares of all non-negative integers less than the given integer.

#### Input Format
A single integer.

#### Output Format
Print the square of each non-negative integer less than the given integer.

#### Example
**Input:**
```
5
```

**Output:**
```
0
1
4
9
16
```

```python
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
        print(i**2)
```

### **Leap Year Checker**

#### Task
Determine whether a given year is a leap year.

#### Input Format
A single integer, the year to test.

#### Output Format
Print `True` if the year is a leap year, otherwise print `False`.

#### Example
**Input:**
```
1990
```

**Output:**
```
False
```

```python
def is_leap(year):
    return year % 4 == 0 and (year % 100 != 0 or year % 400 == 0)

if __name__ == '__main__':
    year = int(input())
    print(is_leap(year))
```

### **Concatenation of Integers**

#### Task
Read an integer and print the concatenation of integers from 1 to n without spaces.

#### Input Format
A single integer.

#### Output Format
Print the concatenated string of integers.

#### Example
**Input:**
```
3
```

**Output:**
```
123
```

```python
if __name__ == '__main__':
    n = int(input())
    print("".join(map(str, range(1, n + 1))))
```

### **Cuboid Coordinates**

#### Task
Given the dimensions of a cuboid and an integer n, print all possible coordinates where the sum of the coordinates is not equal to n.

#### Input Format
Four integers, x, y, z, and n.

#### Output Format
Print the list of valid coordinates.

#### Example
**Input:**
```
1
1
1
2
```

**Output:**
```
[[0, 0, 0], [0, 0, 1], [0, 1, 0], [1, 0, 0], [1, 1, 1]]
```

```python
if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())
    print([[i, j, k] for i in range(x + 1) for j in range(y + 1) for k in range(z + 1) if (i + j + k) != n])
```

### **List of Student Names with Second Lowest Grade**

#### Task
Given the names and grades of students, print the names of students with the second lowest grade.

#### Input Format
- The first line contains an integer, the number of students.
- Each subsequent line contains a student's name and grade.

#### Output Format
Print the names of students with the second lowest grade, sorted alphabetically.

#### Example
**Input:**
```
5
Harry
37.21
Berry
37.21
Tina
37.2
Akriti
41
Harsh
39
```

**Output:**
```
Berry
Harry
```

```python
if __name__ == '__main__':
    students = []
    scores = []
    for _ in range(int(input())):
        name = input()
        score = float(input())
        students.append((name, score))
        scores.append(score)
    second_lowest_score = sorted(set(scores))[1]
    names = sorted(name for name, score in students if score == second_lowest_score)
    for name in names:
        print(name)
```

### **Average of Student Marks**

#### Task
Given a dictionary of student names and their marks, print the average marks of the queried student.

#### Input Format
- The first line contains an integer, the number of students.
- Each subsequent line contains a student's name and their marks.
- The final line contains the name of the student to query.

#### Output Format
Print the average of the marks obtained by the queried student.

#### Example
**Input:**
```
3
Krishna 67 68 69
Arjun 70 98 63
Malika 52 56 60
Malika
```

**Output:**
```
56.00
```

```python
if __name__ == '__main__':
    n = int(input())
    student_marks = {}
    for _ in range(n):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    query_name =

 input()
    average = sum(student_marks[query_name]) / len(student_marks[query_name])
    print(f"{average:.2f}")
```

### **List Operations Based on Commands**

#### Task
Perform various operations on a list based on a sequence of commands.

#### Input Format
- The first line contains an integer, the number of commands.
- Each subsequent line contains a command.

#### Output Format
For each `print` command, print the list.

#### Example
**Input:**
```
12
insert 0 5
insert 1 10
insert 0 6
print
remove 6
append 9
append 1
sort
print
pop
reverse
print
```

**Output:**
```
[6, 5, 10]
[1, 5, 9, 10]
[9, 5, 1]
```

```python
if __name__ == '__main__':
    count = int(input())
    array = []
    for i in range(count):
        command, *key = input().split()
        if command == "insert":
            array.insert(int(key[0]), int(key[1]))
        elif command == "print":
            print(array)
        elif command == "remove":
            array.remove(int(key[0]))
        elif command == "append":
            array.append(int(key[0]))
        elif command == "sort":
            array.sort()
        elif command == "pop":
            array.pop()
        elif command == "reverse":
            array.reverse()
```

### **Hashing a Tuple**

#### Task
Read integers, create a tuple, and return its hash.

#### Input Format
- The first line contains an integer, the number of elements.
- The second line contains the space-separated integers.

#### Output Format
Print the hash of the tuple.

#### Example
**Input:**
```
2
1 2
```

**Output:**
```
3713081631934410656
```

```python
if __name__ == '__main__':
    n = int(input())
    integer_list = tuple(map(int, input().split()))
    print(hash(integer_list))
```

### **Case Swapping in a String**

#### Task
Convert all lowercase letters to uppercase and vice versa in a given string.

#### Input Format
A single line containing a string.

#### Output Format
Print the modified string.

#### Example
**Input:**
```
HackerRank.com presents "Pythonist 2".
```

**Output:**
```
hACKERrANK.COM PRESENTS "pYTHONIST 2".
```

```python
def swap_case(word):
    return word.swapcase()

if __name__ == '__main__':
    s = input()
    result = swap_case(s)
    print(result)
```

### **Split and Join a String**

#### Task
Split a string on spaces and join using hyphens.

#### Input Format
A single line containing a string of space-separated words.

#### Output Format
Print the resulting string with words joined by hyphens.

#### Example
**Input:**
```
this is a string
```

**Output:**
```
this-is-a-string
```

```python
def split_and_join(line):
    return '-'.join(line.split())

if __name__ == '__main__':
    line = input()
    result = split_and_join(line)
    print(result)
```

### Docker Learnings

In this section, I will share my learnings about Docker and how to create and run a container for Node.js.

#### What is Docker?
Docker is an open-source platform that allows you to automate the deployment, scaling, and management of applications using containerization. Containers are lightweight, isolated environments that package everything needed to run an application, including the code, runtime, system tools, and libraries.

#### Creating a Container for Node.js
To create a container for Node.js, follow these steps:

1. Install Docker: First, you need to install Docker on your machine. Visit the official Docker website and download the appropriate version for your operating system.

2. Create a Dockerfile: The Dockerfile is a text file that contains instructions for building a Docker image. Create a new file called `Dockerfile` in your project directory and add the following content:

```Dockerfile
# Use an official Node.js runtime as the base image
FROM node:14

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code to the container
COPY . .

# Expose a port for the application to listen on
EXPOSE 3000

# Define the command to run when the container starts
CMD [ "node", "app.js" ]
```

3. Build the Docker Image: Open a terminal or command prompt, navigate to your project directory, and run the following command to build the Docker image:

```bash
docker build -t my-node-app .
```

This command will build the Docker image using the instructions in the Dockerfile and tag it with the name `my-node-app`.

4. Run the Container: Once the image is built, you can run a container based on that image using the following command:

```bash
docker run -it --rm -p 3000:3000 my-node-app
```

This command will start a new container based on the `my-node-app` image, allocate a pseudo-TTY for interaction, and map port 3000 of the container to port 3000 of the host machine. The `--rm` flag ensures that the container is automatically removed when it stops.

5. Access the Console: With the container running, you can access the console of the container by opening a new terminal or command prompt and running the following command:

```bash
docker exec -it <container_id> /bin/bash
```

Replace `<container_id>` with the ID of the running container. This command will open a shell inside the container, allowing you to interact with it.

That's it! You have successfully created a container for a Node.js application and accessed the console of the running container.

Remember to stop the container when you're done by pressing `Ctrl+C` in the terminal where the container is running.
