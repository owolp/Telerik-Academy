using System;
using System.Collections.Generic;

namespace NineGagNumbers
{
    class NineGagNumbers
    {
        static void Main()
        {
            ulong @base = 9;

            Console.WriteLine(BaseToDec(@base, SpecialToBase(Console.ReadLine())));
        }

        static Dictionary<string, int> Dictionary = new Dictionary<string, int>()
        {
            { "-!" , 0 },
            { "**" , 1 },
            { "!!!" , 2 },
            { "&&" , 3 },
            { "&-" , 4 },
            { "!-" , 5 },
            { "*!!!" , 6 },
            { "&*!" , 7 },
            { "!!**!-" , 8 }
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

                if ('0' <= specialNumber[i] && specialNumber[i] <= '8')
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