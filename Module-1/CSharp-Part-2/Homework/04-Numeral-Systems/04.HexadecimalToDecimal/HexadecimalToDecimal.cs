using System;

namespace HexadecimalToDecimal
{
    class HexadecimalToDecimal
    {
        static void Main()
        {
            string number = Console.ReadLine();

            Console.WriteLine(HexToDec(number));
        }

        static long HexToDec(string hexadecimalNumber)
        {
            long decimalNumber = 0;
            hexadecimalNumber = hexadecimalNumber.ToUpper();

            for (int i = 0; i < hexadecimalNumber.Length; i++)
            {
                int digit = 0;

                if ('0' <= hexadecimalNumber[i] && hexadecimalNumber[i] <= '9')
                {
                    digit = hexadecimalNumber[i] - '0';
                }
                else if ('A' <= hexadecimalNumber[i] && hexadecimalNumber[i] <= 'F')
                {
                    digit = hexadecimalNumber[i] - 'A' + 10;
                }

                int position = hexadecimalNumber.Length - i - 1;
                decimalNumber += digit * GetPower(16, position);
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