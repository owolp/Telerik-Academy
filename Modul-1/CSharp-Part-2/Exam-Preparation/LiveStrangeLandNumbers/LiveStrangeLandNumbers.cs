namespace LiveStrangeLandNumbers
{
    using System;
    using System.Collections.Generic;

    class LiveStrangeLandNumbers
    {
        static Dictionary<string, int> Dict = new Dictionary<string, int>()
        {
            { "f", 0 },
            { "bIN", 1 },
            { "oBJEC", 2 },
            { "mNTRAVL", 3 },
            { "lPVKNQ", 4 },
            { "pNWE", 5 },
            { "hT", 6 },
        };

        static void Main()
        {
            var strangeNumber = Console.ReadLine();
            Console.WriteLine(BaseToDec(7, Translate(strangeNumber)));
        }

        static string Translate(string strangeNumber)
        {
            string partialInput = string.Empty;
            string baseNumber = string.Empty;

            for (int i = 0; i < strangeNumber.Length; i++)
            {
                partialInput += strangeNumber[i];

                if (Dict.ContainsKey(partialInput))
                {
                    var number = Dict[partialInput];
                    baseNumber += number;
                    partialInput = string.Empty;
                }
            }

            return baseNumber;
        }

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

                int position = baseNumber.Length - i - 1;

                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
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
