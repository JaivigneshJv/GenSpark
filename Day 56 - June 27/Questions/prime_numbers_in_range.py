# average_of_primes.py

def is_prime(num):
    if num <= 1:
        return False
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

numbers = []
for _ in range(10):
    number = int(input("Enter a number: "))
    numbers.append(number)

prime_numbers = [num for num in numbers if is_prime(num)]
if prime_numbers:
    average = sum(prime_numbers) / len(prime_numbers)
    print(f"The average of the prime numbers is: {average}")
else:
    print("No prime numbers found.")
