using System;
using System.Linq;
using System.Text;

namespace Zerg
{
    class Zerg
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            ulong baseIn = 15;

            string[] words = ConvertToStringArr(inputString);

            Console.WriteLine(GetSum(words, baseIn));
        }

        static string[] ConvertToStringArr(string inputString)
        {
            var word = "";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < inputString.Length; i++)
            {
                char letter = inputString[i];

                if (char.IsUpper(letter) && word != string.Empty)
                {
                    sb.AppendFormat("{0} ", word);
                    word = Convert.ToString(letter);
                }
                else if (i == inputString.Length - 1)
                {
                    word += letter;
                    sb.AppendFormat("{0}", word);
                }
                else
                {
                    word += letter;
                }
            }

            string outputString = Convert.ToString(sb);
            string[] words = outputString.Split(' ').ToArray();

            return words;
        }

        static ulong GetValue(string word)
        {
            switch (word)
            {
                case "Rawr": return 0;
                case "Rrrr": return 1;
                case "Hsst": return 2;
                case "Ssst": return 3;
                case "Grrr": return 4;
                case "Rarr": return 5;
                case "Mrrr": return 6;
                case "Psst": return 7;
                case "Uaah": return 8;
                case "Uaha": return 9;             
                case "Zzzz": return 10;
                case "Bauu": return 11;
                case "Djav": return 12;
                case "Myau": return 13;
                case "Gruh": return 14;
                default: throw new ArgumentException();
            }
        }

        static ulong GetPower(ulong baseIn, int power)
        {
            ulong result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseIn;
            }

            return result;
        }

        static ulong GetSum(string[] words, ulong baseIn)
        {
            ulong sum = 0;
            int power = 0;

            for (int i = words.Length - 1; i >= 0; i--)
            {
                ulong wordValue = GetValue(words[i]);
                sum += (wordValue * GetPower(baseIn, power));
                power++;
            }

            return sum;
        }
    }
}