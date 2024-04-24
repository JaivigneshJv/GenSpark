namespace Day3
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            MenuMain();
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice! Please enter a valid integer.");
                Console.Write("Enter your choice: ");
            }

            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        ClearConsole();
                        ArithmeticOperations.ArithmeticOperation();
                        break;
                    case 2:
                        ClearConsole();
                        GreatestNumber.GreatestNumbers();
                        break;
                    case 3:
                        ClearConsole();
                        AverageNum7.AvgNum7();
                        break;
                    case 4:
                        ClearConsole();
                        UserLength.CalculateInputLength();
                        break;
                    case 5:
                        ClearConsole();
                        UserLogin.UserLoginDetails();
                        break;
                    case 6:
                        ClearConsole();
                        RepeatingVowels.StringRepeatingVowel();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue or 0 to exit to main menu.");
                Console.ReadKey();
                Console.Clear();

                MenuMain();
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice! Please enter a valid integer.");
                    Console.Write("Enter your choice: ");
                }
            }
        }

        static void ClearConsole()
        {
            Console.Clear();
        }
        static void MenuMain()
        {
            Console.WriteLine("GenSpark Training \n");
            Console.WriteLine("Day 3 - C# Programming \n");
            Console.WriteLine("1. Arithmetic Operations on 2 numbers \n");
            Console.WriteLine("2. Greatest of the given numbers \n");
            Console.WriteLine("3. Average of all numbers that are divisible by 7 \n");
            Console.WriteLine("4. Length of user input \n");
            Console.WriteLine("5. Login Validation \n");
            Console.WriteLine("6. String Manipulation \n ");
            Console.WriteLine("0. Exit \n \n");
            Console.Write("Enter your choice: ");
        }
    }
}
