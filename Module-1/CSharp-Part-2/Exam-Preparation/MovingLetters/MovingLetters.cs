namespace MovingLetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MovingLetters
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();
            ExtractLetters(words);
            MoveLetters(ExtractLetters(words));
        }

        static StringBuilder ExtractLetters(string[] words)
        {
            string extractedString = string.Empty;

            int maxLength = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLength)
                {
                    maxLength = words[i].Length;
                }
            }

            StringBuilder sb = new StringBuilder();

            for (int digitIndex = 0; digitIndex < maxLength; digitIndex++)
            {
                for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
                {
                    if (words[wordIndex].Length > digitIndex)
                    {
                        sb.Append(words[wordIndex][words[wordIndex].Length - digitIndex - 1]);
                    }
                }
            }

            return sb;
        }

        static void MoveLetters(StringBuilder word)
        {

            for (int currentPosition = 0; currentPosition < word.Length; currentPosition++)
            {
                char letter = word[currentPosition];
                char currentLetterToLower = char.ToLower(word[currentPosition]);

                int positionsToMove = currentLetterToLower - 'a' + 1;

                word.Remove(currentPosition, 1);
                int newPosition = (currentPosition + positionsToMove) % (word.Length + 1);
                word.Insert(newPosition, letter);
            }

            Console.WriteLine(word);
        }
    }
}