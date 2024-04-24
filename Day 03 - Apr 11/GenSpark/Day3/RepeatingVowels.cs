namespace Day3
{
    class RepeatingVowels
    {
        public static void StringRepeatingVowel()
        {
            Console.Write("Enter a string of words separated by commas: ");
            string? input = Console.ReadLine();

            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            string[] words = input?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(word => word.Trim())
                                  .ToArray() ?? new string[0];

            Dictionary<string, int> wordVowelCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                int repeatingVowelCount = CalculateRepeatingVowels(word, vowels);
                wordVowelCounts[word] = repeatingVowelCount;
            }

            int minVowelCount = wordVowelCounts.Values.Min();

            var wordsWithMinVowelCount = wordVowelCounts
                .Where(pair => pair.Value == minVowelCount)
                .Select(pair => pair.Key)
                .ToList();

            Console.WriteLine($"Number of words: {words.Length}");
            Console.WriteLine($"Count of least repeating vowels: {minVowelCount}");
            Console.WriteLine($"Words with the least repeating vowels: {string.Join(", ", wordsWithMinVowelCount)}");
        }

        static int CalculateRepeatingVowels(string word, HashSet<char> vowels)
        {
            int repeatingVowelCount = 0;
            HashSet<char> encounteredVowels = new HashSet<char>();

            foreach (char c in word.ToLower())
            {
                if (vowels.Contains(c))
                {
                    if (!encounteredVowels.Add(c))
                    {
                        repeatingVowelCount++;
                    }
                }
            }

            return repeatingVowelCount;
        }
    }
}
