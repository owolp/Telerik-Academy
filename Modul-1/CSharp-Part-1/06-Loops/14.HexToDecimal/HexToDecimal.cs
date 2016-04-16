//14. Hex to Decimal
//Description
//Using loops write a program that converts a hexadecimal integer number to its decimal form.
//    The input is entered as string. The output should be a variable of type long.
//    Do not use the built-in .NET functionality.
//Input
//    The input will consists of a single line containing a single hexadecimal number as string.
//Output
//    The output should consist of a single line - the decimal representation of the number as string.
//Constraints
//    All numbers will be valid 64-bit integers.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace HexToDecimal
{
    class HexToDecimal
    {
        static void Main()
        {
            string hexNumber = Console.ReadLine().ToUpper();

            long decimalNumber = 0;
            long power = 1;

            for (int i = hexNumber.Length - 1; i >= 0; i--)
            {
                int n = 0;
                switch (hexNumber[i])
                {
                    case 'A':
                        n = 10;
                        break;
                    case 'B':
                        n = 11;
                        break;
                    case 'C':
                        n = 12;
                        break;
                    case 'D':
                        n = 13;
                        break;
                    case 'E':
                        n = 14;
                        break;
                    case 'F':
                        n = 15;
                        break;
                    default:
                        n = hexNumber[i] - '0';
                        break;
                }

                decimalNumber += n * power;
                power *= 16;
            }

            Console.WriteLine(decimalNumber);
        }
    }
}
