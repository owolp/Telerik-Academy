using System;
using System.Linq;
using System.Text;

namespace DeCatCoding
{
    class DeCatCoding
    {
        static void Main()
        {
            ulong inBase = 21;
            ulong outBase = 26;

            string[] words = ReadStringArray();

            PrintResult(words, inBase, outBase);
        }

        static string[] ReadStringArray()
        {
            return Console.ReadLine().Split(' ').ToArray();
        }

        static ulong BaseToDec(ulong @base, string baseNumber)
        {
            ulong decimalNumber = 0;

            for (int i = 0; i < baseNumber.Length; i++)
            {
                ulong digit = 0;

                if ('a' <= baseNumber[i] && baseNumber[i] <= 'u')
                {
                    digit = (ulong)baseNumber[i] - 'a';
                }

                int position = baseNumber.Length - i - 1;
                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
        }

        static string DecToBase(ulong @base, ulong decimalNumber)
        {
            string baseNumber = string.Empty;

            while (decimalNumber > 0)
            {
                ulong digit = decimalNumber % @base;

                if (0 <= digit && digit <= @base)
                {
                    baseNumber = (char)(digit + 'a') + baseNumber;
                }

                decimalNumber /= @base;
            }

            return baseNumber;
        }

        static ulong GetPower(ulong @base, int position)
        {
            ulong result = 1;

            for (int i = 0; i < position; i++)
            {
                result *= @base;
            }

            return result;
        }

        static ulong GetDecSum(ulong @base, string word)
        {
            return BaseToDec(@base, word);
        }

        static void PrintResult(string[] words, ulong inBase, ulong outBase)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                ulong decimalNumber = GetDecSum(inBase, word);
                string baseWord = DecToBase(outBase, decimalNumber);

                sb.Append(baseWord);
                sb.Append(" ");
            }
          
            Console.WriteLine(sb);
        }
    }
}