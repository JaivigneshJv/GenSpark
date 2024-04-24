namespace Day4
{
    class Numbermani
    {
        static public void NumberManipulation()
        {
            string givenNumber = "";

            bool isValidNumber = false;
            while (!isValidNumber)
            {
                Console.Write("Enter a number: ");
                string? userInput = Console.ReadLine();

                if (long.TryParse(userInput, out long number) && userInput.Length == 16)
                {
                    givenNumber = userInput;
                    isValidNumber = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid 16-digit number.");
                }
            }

            string reversedNumber = ReverseString(givenNumber);
            int totalSum = PerformValidation(reversedNumber);
            Console.WriteLine($"Reversed Number: {reversedNumber}");
            Console.WriteLine($"Total Sum: {totalSum}");
            bool isValid = totalSum % 10 == 0;
            Console.WriteLine(isValid ? "Valid" : "Not Valid");
        }

        /// <summary>
        /// Reverses a given string.
        /// </summary>
        /// <param name="input">The input string to reverse.</param>
        /// <returns>The reversed string.</returns>
        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Performs the validation using the specified method.
        /// </summary>
        /// <param name="number">The reversed number as a string.</param>
        /// <returns>The total sum after processing the number.</returns>
        static int PerformValidation(string number)
        {
            int totalSum = 0;
            bool shouldDouble = false;
            for (int i = 0; i < number.Length; i++)
            {
                int digit = int.Parse(number[i].ToString());
                if (shouldDouble)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        //Optimize 18 being max = 18-9 = 9 17-9 = 8 16-9 = 7
                        digit -= 9;
                    }
                }
                Console.Write(digit);
                totalSum += digit;
                shouldDouble = !shouldDouble;
            }
            return totalSum;
        }
    }
}
