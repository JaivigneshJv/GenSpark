
namespace CRUDApp
{
    internal class Game
    {
        public static void GuessGame()
        {
            Console.Clear();
            Console.Write("Enter your Word: ");
            string? word = Console.ReadLine();
            while (word == null || word.Length != 4)
            {
                Console.WriteLine("Invalid word! Please enter a 4-character word.");
                Console.Write("Enter your Word: ");
                word = Console.ReadLine();
            }
            Console.Clear();

            word = word.ToLower();
            int cows, bulls;

            Console.WriteLine($"The word is a {word.Length}-character word. You have to guess the word.\n");

            while (true)
            {
                Console.Write("Enter your guess: ");
                string? guess = Console.ReadLine();
                guess = guess?.ToLower();

                if (guess == null || guess.Length != 4)
                {
                    Console.WriteLine("Invalid guess! Please enter a 4-character word.");
                    continue;
                }

                cows = 0;
                bulls = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    if (guess[i] == word[i])
                    {
                        cows++;
                    }
                    else if (word.Contains(guess[i]) && guess[i] != word[i])
                    {
                        bulls++;
                    }
                }

                Console.WriteLine($"cows - {cows}, bulls - {bulls}\n");

                if (cows == 4)
                {
                    Console.WriteLine("Congrats!!! You won!!!!!");
                    break;
                }
            }
        }
    }
}
