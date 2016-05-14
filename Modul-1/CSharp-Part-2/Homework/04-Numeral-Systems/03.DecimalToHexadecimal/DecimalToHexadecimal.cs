using System;

namespace DecimalToHexadecimal
{
    class DecimalToHexadecimal
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine(DecToHex(number));
        }

        static string DecToHex(long decimalNumber)
        {
            string hexadecimalNumber = string.Empty;

            while (decimalNumber > 0)
            {
                long digit = decimalNumber % 16;

                if (0 <= digit && digit <= 9)
                {
                    hexadecimalNumber = (char)(digit + '0') + hexadecimalNumber;
                }
                else if (10 <= digit && digit <= 15)
                {
                    hexadecimalNumber = (char)(digit - 10 + 'A') + hexadecimalNumber;
                }

                decimalNumber /= 16;
            }

            return hexadecimalNumber;
        }
    }
}