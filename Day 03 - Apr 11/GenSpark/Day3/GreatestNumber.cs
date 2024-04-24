namespace Day3
{
    class GreatestNumber
    {
        public static void GreatestNumbers()
        {
            double greatestNumber = double.MinValue;
            double currentNumber;
            Console.WriteLine("Enter numbers to find the greatest one. Enter a negative number to stop.");

            while (true)
            {
                Console.Write("Enter a number: ");
                if (!double.TryParse(Console.ReadLine(), out currentNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                if (currentNumber < 0)
                {
                    break;
                }

                if (currentNumber > greatestNumber)
                {
                    greatestNumber = currentNumber;
                }
            }

            if (greatestNumber == double.MinValue)
            {
                Console.WriteLine("No valid numbers were entered.");
            }
            else
            {
                Console.WriteLine($"The greatest number entered is: {greatestNumber}");
            }
        }
    }
}
