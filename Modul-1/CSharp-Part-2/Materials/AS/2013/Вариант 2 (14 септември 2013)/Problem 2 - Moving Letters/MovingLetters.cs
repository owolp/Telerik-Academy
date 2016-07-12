using System;
using System.Text;

class MovingLetters
{
    static void Main()
    {
        // Read the words from the console
        string inputWords = Console.ReadLine();
        string[] words = inputWords.Split(' ');

        // Find the longest word
        int longestWord = 0;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > longestWord)
            {
                longestWord = words[i].Length;
            }
        }

        // Extract the letters
        StringBuilder letters = new StringBuilder();
        for (int index = 0; index < longestWord; index++)
        {
            for (int i = 0; i < words.Length; i++)
            {
                int currentLetterIndex = words[i].Length - 1 - index;
                if (currentLetterIndex >= 0)
                {
                    letters.Append(words[i][currentLetterIndex]);
                }
            }
        }

        // Move each letter to its new position
        for (int pos = 0; pos < letters.Length; pos++)
        {
            char letter = letters[pos];
            int positions = char.ToLower(letter) - 'a' + 1;
            MoveRight(letters, pos, positions);
        }

        Console.WriteLine(letters);
    }

    static void MoveRight(StringBuilder letters, int pos, int positions)
    {
        char letter = letters[pos];
        letters.Remove(pos, 1);
        int newPos = (pos + positions) % (letters.Length + 1);
        letters.Insert(newPos, letter);
    }
}
