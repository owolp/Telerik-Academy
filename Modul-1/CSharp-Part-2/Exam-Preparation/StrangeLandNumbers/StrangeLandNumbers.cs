using System;
using System.Collections.Generic;

namespace StrangeLandNumbers
{
    class StrangeLandNumbers
    {
        static void Main()
        {
            ulong inBase = 7;

            Console.WriteLine(BaseToDec(inBase, SpecialToBase(Console.ReadLine())));
        }

        static Dictionary<string, int> Dictionary = new Dictionary<string, int>
        {
            { "f" , 0 },
            { "bIN" , 1 },
            { "oBJEC" , 2 },
            { "mNTRAVL" , 3 },
            { "lPVKNQ" , 4 },
            { "pNWE" , 5 },
            { "hT" , 6 }
        };

        static string SpecialToBase(string word)
        {
            string result = string.Empty;

            string partialInput = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                partialInput += word[i];

                if (Dictionary.ContainsKey(partialInput))
                {
                    result += Dictionary[partialInput];
                    partialInput = string.Empty;
                }
            }

            return result;
        }

        static ulong BaseToDec(ulong @base, string specialNumber)
        {
            ulong decimalNumber = 0;

            for (int i = 0; i < specialNumber.Length; i++)
            {
                ulong digit = 0;

                if ('0' <= specialNumber[i] && specialNumber[i] <= '6')
                {
                    digit = (ulong)(specialNumber[i] - '0');
                }

                int position = specialNumber.Length - i - 1;

                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
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
    }
}