namespace Day3
{
    internal class UserLength
    {
        public static void CalculateInputLength()
        {
            Console.Write("Enter your name: ");
            string? userName = Console.ReadLine();

            if (userName != null)
            {
                int nameLength;
                if (int.TryParse(userName, out nameLength))
                {
                    Console.WriteLine($"The length of your name is: {nameLength}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
            }
        }
    }
}
