using System;

namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            string number = Console.ReadLine();

            Console.WriteLine(BinToDec(number));
        }

        static long BinToDec(string binaryNumber)
        {
            long decimalNumber = 0;

            for (int i = 0; i < binaryNumber.Length; i++)
            {
                int digit = binaryNumber[i] - '0';
                int position = binaryNumber.Length - i - 1;
                decimalNumber += digit * GetPower(2, position);
            }

            return decimalNumber;
        }

        static long GetPower(int @base, int position)
        {
            long result = 1;

            for (int i = 0; i < position; i++)
            {
                result *= @base;
            }

            return result;
        }
    }
}