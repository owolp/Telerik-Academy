using System;
using System.Collections.Generic;

namespace BinaryToHexadecimal
{
    class BinaryToHexadecimal
    {
        static void Main()
        {
            string number = Console.ReadLine();
            number = number.PadLeft(60, '0');

            Console.WriteLine(DeleteLeadingZeroes(BinToHex(number)));
        }

        static Dictionary<string, string> BinToHexDictionary = new Dictionary<string, string>()
        {
            { "0000", "0" },
            { "0001", "1" },
            { "0010", "2" },
            { "0011", "3" },
            { "0100", "4" },
            { "0101", "5" },
            { "0110", "6" },
            { "0111", "7" },
            { "1000", "8" },
            { "1001", "9" },
            { "1010", "A" },
            { "1011", "B" },
            { "1100", "C" },
            { "1101", "D" },
            { "1110", "E" },
            { "1111", "F" },
        };    

        static string BinToHex(string binaryNumber)
        {
            string hexadecimalNumber = string.Empty;
            string partialInput = string.Empty;
            string value = string.Empty;

            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                partialInput = binaryNumber[i] + partialInput;

                if (BinToHexDictionary.TryGetValue(partialInput, out value))
                {
                    hexadecimalNumber = BinToHexDictionary[partialInput] + hexadecimalNumber;

                    partialInput = string.Empty;
                }
            }

            return hexadecimalNumber;
        }

        static string DeleteLeadingZeroes(string number)
        {
            string formattedString = number.TrimStart('0');

            if (formattedString == string.Empty)
            {
                formattedString = "0";
            }

            return formattedString;
        }
    }
}