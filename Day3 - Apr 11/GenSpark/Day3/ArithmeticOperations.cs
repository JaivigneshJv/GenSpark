namespace Day3
{
    class ArithmeticOperations
    {
        public static void ArithmeticOperation()
        {
            try
            {
                double firstNumber = 0; 
                bool validFirstNumber = false;
                while (!validFirstNumber)
                {
                    Console.Write("Enter the first number: ");
                    if (!double.TryParse(Console.ReadLine(), out firstNumber))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    else
                    {
                        validFirstNumber = true;
                    }
                }

                double secondNumber = 0;
                bool validSecondNumber = false;
                while (!validSecondNumber)
                {
                    Console.Write("Enter the second number: ");
                    if (!double.TryParse(Console.ReadLine(), out secondNumber))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    else
                    {
                        validSecondNumber = true;
                    }
                }

                Console.WriteLine("Sum: " + CalculateSum(firstNumber, secondNumber));
                Console.WriteLine("Product: " + CalculateProduct(firstNumber, secondNumber));
                Console.WriteLine("Difference: " + CalculateDifference(firstNumber, secondNumber));
                Console.WriteLine("Quotient: " + CalculateQuotient(firstNumber, secondNumber));
                Console.WriteLine("Remainder: " + CalculateRemainder(firstNumber, secondNumber));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        static double CalculateSum(double a, double b)
        {
            return a + b;
        }

        static double CalculateProduct(double a, double b)
        {
            return a * b;
        }

        static double CalculateDifference(double a, double b)
        {
            return a - b;
        }

        static double CalculateQuotient(double a, double b)
        {
            const double tolerance = 1e-9;
            if (Math.Abs(b) < tolerance)
            {
                throw new DivideByZeroException("Division by zero.");
            }
            return a / b;
        }

        static double CalculateRemainder(double a, double b)
        {
            const double tolerance = 1e-9;
            if (Math.Abs(b) < tolerance)
            {
                throw new DivideByZeroException("Division by zero.");
            }
            return a % b;
        }
    }
    }

