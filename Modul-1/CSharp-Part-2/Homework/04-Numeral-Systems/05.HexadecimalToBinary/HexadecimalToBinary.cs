using System;
using System.Collections.Generic;

namespace HexadecimalToBinary
{
    class HexadecimalToBinary
    {
        static void Main()
        {
            string number = Console.ReadLine();

            Console.WriteLine(DeleteLeadingZeroes(HexToBin(number)));
        }

        static Dictionary<char, string> HexToBinDictionary = new Dictionary<char, string>()
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" },
        };

        static string HexToBin(string hexadecimalNumber)
        {
            string binaryNumber = string.Empty;

            foreach (char hexadecimalDigit in hexadecimalNumber)
            {
                binaryNumber = binaryNumber + HexToBinDictionary[hexadecimalDigit];
            }

            return binaryNumber;
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