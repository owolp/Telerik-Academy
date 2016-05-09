using System;
using System.Linq;
using System.Text;

namespace DeCatCoding
{
    class DeCatCoding
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            int inBase = 21;
            int outBase = 26;

            string[] words = inputString.Split(' ').ToArray();

            StringBuilder newWords = new StringBuilder();
            //string[] newWords = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var index = word.Length - 1;
                long sum21Base = 0;

                for (int j = 0; j < word.Length; j++)
                {
                    long symbol21Base = word[j] - 'a';
                    symbol21Base *= (long)Math.Pow(inBase, index);
                    sum21Base += symbol21Base;

                    index--;
                }

                var resultString = "";

                while (sum21Base > 0)
                {
                    long symbol26Base = sum21Base % outBase;
                    sum21Base /= outBase;
                    symbol26Base += 'a';

                    char symbol = (char)symbol26Base;

                    resultString = symbol + resultString;

                }

                newWords.AppendFormat("{0} ", resultString);
                //newWords[i] = resultString;

            }

            Console.WriteLine(newWords);
            //Console.WriteLine(string.Join(" ", newWords));
        }
    }
}