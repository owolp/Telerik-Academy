using System;
using System.Linq;

namespace CalculationProblem
{
    class CalculationProblem
    {
        static void Main()
        {
            int inBase = 23;
            // int outBase = 19;

            string[] words = ReadStringArray();

            int decimalNumber = GetDecSum(inBase, words);
            string baseWord = DecToBase(inBase, decimalNumber);

            Console.WriteLine(baseWord + " = " + decimalNumber);

        }

        static string[] ReadStringArray()
        {
            return Console.ReadLine().Split(' ').ToArray();
        }

        static int BaseToDec(int @base, string baseNumber)
        {
            int decimalNumber = 0;

            for (int i = 0; i < baseNumber.Length; i++)
            {
                int digit = 0;

                if ('a' <= baseNumber[i] && baseNumber[i] <= 'w')
                {
                    digit = baseNumber[i] - 'a';
                }

                int position = baseNumber.Length - i - 1;
                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
        }

        static string DecToBase(int @base, int decimalNumber)
        {
            string baseNumber = string.Empty;

            while (decimalNumber > 0)
            {
                int digit = decimalNumber % @base;

                if (0 <= digit && digit <= @base)
                {
                    baseNumber = (char)(digit + 'a') + baseNumber;
                }

                decimalNumber /= @base;
            }

            return baseNumber;
        }

        static int GetPower(int @base, int position)
        {
            int result = 1;

            for (int i = 0; i < position; i++)
            {
                result *= @base;
            }

            return result;
        }

        static int GetDecSum(int @base, string[] words)
        {
            int sum = 0;

            for (int i = 0; i < words.Length; i++)
            {
                sum += BaseToDec(@base, words[i]);
            }

            return sum;
        }
    }
}