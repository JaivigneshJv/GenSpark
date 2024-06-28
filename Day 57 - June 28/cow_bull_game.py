import random

def generate_secret_word():
    words = ["apple", "banana", "grape", "mango", "peach"]
    return random.choice(words)

def get_cows_and_bulls(secret, guess):
    cows = bulls = 0
    for s, g in zip(secret, guess):
        if s == g:
            cows += 1
        elif g in secret:
            bulls += 1
    return cows, bulls

secret_word = generate_secret_word()
max_attempts = 10
attempts = 0

print("Welcome to the Cow and Bull Game!")
print("Guess the 5-letter word.")

while attempts < max_attempts:
    guess = input("Enter your guess: ").lower()
    if len(guess) != 5:
        print("Please enter a 5-letter word.")
        continue

    attempts += 1
    cows, bulls = get_cows_and_bulls(secret_word, guess)
    print(f"Cows: {cows}, Bulls: {bulls}")

    if cows == 5:
        print("Congratulations! You guessed the word correctly.")
        break
else:
    print(f"Sorry, you've used all attempts. The word was: {secret_word}")
