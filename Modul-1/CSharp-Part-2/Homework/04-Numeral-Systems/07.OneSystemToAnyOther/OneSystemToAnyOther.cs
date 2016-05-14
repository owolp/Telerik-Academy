using System;
using System.Numerics;

namespace OneSystemToAnyOther
{
    class OneSystemToAnyOther
    {
        static void Main()
        {
            int baseIn = int.Parse(Console.ReadLine());
            string number = Console.ReadLine().ToUpper();
            int baseOut = int.Parse(Console.ReadLine());

            Console.WriteLine(DecToBase(baseOut, BaseToDec(baseIn, number)));
        }

        static BigInteger BaseToDec(int @base, string hexadecimalNumber)
        {
            BigInteger decimalNumber = 0;

            for (int i = 0; i < hexadecimalNumber.Length; i++)
            {
                int digit = 0;

                if ('0' <= hexadecimalNumber[i] && hexadecimalNumber[i] <= '9')
                {
                    digit = hexadecimalNumber[i] - '0';
                }
                else if ('A' <= hexadecimalNumber[i] && hexadecimalNumber[i] <= 'Z')
                {
                    digit = hexadecimalNumber[i] - 'A' + 10;
                }

                int position = hexadecimalNumber.Length - i - 1;
                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
        }

        static string DecToBase(int @base, BigInteger decimalNumber)
        {
            string hexadecimalNumber = string.Empty;

            while (decimalNumber > 0)
            {
                BigInteger digit = decimalNumber % @base;

                if (0 <= digit && digit <= 9)
                {
                    hexadecimalNumber = (char)(digit + '0') + hexadecimalNumber;
                }
                else if (10 <= digit && digit <= 255)
                {
                    hexadecimalNumber = (char)(digit - 10 + 'A') + hexadecimalNumber;
                }

                decimalNumber /= @base;
            }

            return hexadecimalNumber;
        }

        static BigInteger GetPower(int @base, int position)
        {
            BigInteger result = 1;

            for (int i = 0; i < position; i++)
            {
                result *= @base;
            }

            return result;
        }
    }
}