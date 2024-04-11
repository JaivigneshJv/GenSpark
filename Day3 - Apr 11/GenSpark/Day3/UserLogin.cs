namespace Day3
{
    class UserLogin
    {
        public static void UserLoginDetails()
        {
            string CorrectUsername = "Jv";
            string CorrectPassword = "123";
            int MaxAttempts = 3;
            int attempts = 0;
            bool isAuthenticated = false;

            while (attempts < MaxAttempts && !isAuthenticated)
            {
                Console.Write("Enter username: ");
                string? username = Console.ReadLine();

                Console.Write("Enter password: ");
                string? password = Console.ReadLine();

                if (username == CorrectUsername && password == CorrectPassword)
                {
                    Console.WriteLine("Login successful!");
                    isAuthenticated = true;
                }
                else
                {
                    attempts++;

                    if (attempts < MaxAttempts)
                    {
                        Console.WriteLine("Error: Invalid username or password. Please try again.");
                    }
                    else
                    {
                        Console.WriteLine("Error: You have exceeded the number of attempts. Please try again later.");
                    }
                }
            }
        }
    }
}
