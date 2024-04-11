namespace Day3
{
    class AverageNum7
    {
        public static void AvgNum7()
        {
            int sum = 0;
            int count = 0;

            Console.WriteLine("Enter numbers to find the average of numbers divisible by 7.");
            Console.WriteLine("Enter a negative number to stop.");

            while (true)
            {
                Console.Write("Enter a number: ");
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }

                if (number < 0)
                {
                    break;
                }

                if (number % 7 == 0)
                {
                    sum += number;
                    count++;
                }
            }

            if (count > 0)
            {
                double average = (double)sum / count;
                Console.WriteLine($"The average of numbers divisible by 7 is: {average}");
            }
            else
            {
                Console.WriteLine("No numbers divisible by 7 were entered.");
            }
        }
    }
}
