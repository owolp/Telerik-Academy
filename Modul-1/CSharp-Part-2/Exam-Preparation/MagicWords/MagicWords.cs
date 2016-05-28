namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class MagicWords
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> words = ReadInput(n);
            List<string> reorderedWords = Reorder(words);
            Print(reorderedWords);
        }

        static List<string> ReadInput(int n)
        {
            List<string> words = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                words.Add(input);
            }

            return words;
        }

        static List<string> Reorder(List<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i];

                int position = currentWord.Length % (words.Count + 1);

                words[i] = null;
                words.Insert(position, currentWord);
                words.Remove(null);
            }

            return words;
        }

        static void Print(List<string> words)
        {
            int maxLength = 0;

            foreach (string word in words)
            {
                int wordLength = word.Count();
                if (wordLength > maxLength)
                {
                    maxLength = wordLength;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (words[j].Length > i)
                    {
                        sb.Append(words[j][i]);
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}