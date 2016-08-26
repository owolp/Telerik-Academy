using System;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine(DecToBinary(number));

        }

        static string DecToBinary(long decimalNumber)
        {
            string binaryNumber = string.Empty;

            while (decimalNumber > 0)
            {
                long digit = decimalNumber % 2;

                binaryNumber = digit + binaryNumber;

                decimalNumber /= 2;
            }

            return binaryNumber;
        }
    }
}