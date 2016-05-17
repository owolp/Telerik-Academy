using System;
using System.Collections.Generic;

namespace MultiverseCommunication
{
    class MultiverseCommunication
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int inBase = 13;

            Console.WriteLine(BaseToDec(inBase, BaseToSpecial(input)));
        }

        static Dictionary<string, int> Dictionary = new Dictionary<string, int>()
        {
            { "CHU" , 0 },
            { "TEL" , 1 },
            { "OFT" , 2 },
            { "IVA" , 3 },
            { "EMY" , 4 },
            { "VNB" , 5 },
            { "POQ" , 6 },
            { "ERI" , 7 },
            { "CAD" , 8 },
            { "K-A" , 9 },
            { "IIA" , 10 },
            { "YLO" , 11 },
            { "PLA" , 12 },
        };

        static ulong BaseToDec(int @base, string baseNumber)
        {
            ulong decimalNumber = 0;

            for (int i = 0; i < baseNumber.Length; i++)
            {
                ulong digit = 0;

                if ('0' <= baseNumber[i] && baseNumber[i] <= '9')
                {
                    digit = (ulong)baseNumber[i] - '0';
                }
                else if ('A' <= baseNumber[i] && baseNumber[i] <= 'C')
                {
                    digit = (ulong)baseNumber[i] - 'A' + 10;
                }

                int position = baseNumber.Length - i - 1;

                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
        }

        static string BaseToSpecial(string baseNumber)
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
                    else if (10 <= Dictionary[partialInput] && Dictionary[partialInput] <= 12)
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