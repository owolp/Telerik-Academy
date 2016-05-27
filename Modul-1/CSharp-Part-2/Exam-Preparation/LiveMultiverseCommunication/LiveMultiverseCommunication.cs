namespace LiveMultiverseCommunication
{
    using System;
    using System.Collections.Generic;

    class LiveMultiverseCommunication
    {
        static Dictionary<string, char> Dictionary = new Dictionary<string, char>()
        {
            { "CHU" , '0' },
            { "TEL" , '1' },
            { "OFT" , '2' },
            { "IVA" , '3' },
            { "EMY" , '4' },
            { "VNB" , '5' },
            { "POQ" , '6' },
            { "ERI" , '7' },
            { "CAD" , '8' },
            { "K-A" , '9' },
            { "IIA" , 'A' },
            { "YLO" , 'B' },
            { "PLA" , 'C' },
        };

        static void Main()
        {
            var input = Console.ReadLine();

            Translate(input);
            Console.WriteLine(BaseToDec(13, Translate(input)));
        }

        static string Translate(string encryptedMessage)
        {
            string result = string.Empty;
            string partialInput = string.Empty;

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                partialInput += encryptedMessage[i];

                if (Dictionary.ContainsKey(partialInput))
                {
                    result += Dictionary[partialInput];
                    partialInput = string.Empty;
                }
            }


            return result;
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
                else if ('A' <= baseNumber[i] && baseNumber[i] <= 'Z')
                {
                    digit = (ulong)baseNumber[i] - 'A' + 10;
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
