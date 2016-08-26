using System;
using System.Collections.Generic;

namespace Zerg
{
    class Zerg
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int @base = 15;

            Console.WriteLine(ConvertToDec(@base, ConvertToBase(input)));
        }

        static Dictionary<string, int> Dictionary = new Dictionary<string, int>()
        {
            { "Rawr" , 0 },
            { "Rrrr" , 1 },
            { "Hsst" , 2 },
            { "Ssst" , 3 },
            { "Grrr" , 4 },
            { "Rarr" , 5 },
            { "Mrrr" , 6 },
            { "Psst" , 7 },
            { "Uaah" , 8 },
            { "Uaha" , 9 },
            { "Zzzz" , 10 },
            { "Bauu" , 11 },
            { "Djav" , 12 },
            { "Myau" , 13 },
            { "Gruh" , 14 },
        };

        static ulong ConvertToDec(int @base, string baseNumber)
        {
            ulong decimalNumber = 0;

            for (int i = 0; i < baseNumber.Length; i++)
            {
                ulong digit = 0;

                if ('0' <= baseNumber[i] && baseNumber[i] <= '9')
                {
                    digit = (ulong)baseNumber[i] - '0';
                }
                else if ('A' <= baseNumber[i] && baseNumber[i] <= 'Z')
                {
                    digit = (ulong)baseNumber[i] - 'A' + 10;
                }

                int position = baseNumber.Length - i - 1;

                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
        }

        static string ConvertToBase(string baseNumber)
        {
            string partialInput = string.Empty;
            string result = string.Empty;

            for (int i = 0; i < baseNumber.Length; i++)
            {
                partialInput += baseNumber[i];

                if (Dictionary.ContainsKey(partialInput))
                {
                    if (0 <= Dictionary[partialInput] && Dictionary[partialInput] <= 9)
                    {
                        result += Dictionary[partialInput];
                    }
                    else if (10 <= Dictionary[partialInput] && Dictionary[partialInput] <= 14)
                    {
                        result += (char)(Dictionary[partialInput] - 10 + 'A');
                    }

                    partialInput = string.Empty;
                }
            }

            return result;
        }

        static ulong GetPower(int @base, int position)
        {
            ulong result = 1;

            for (int i = 0; i < position; i++)
            {
                result *= (ulong)@base;
            }

            return result;
        }
    }
}