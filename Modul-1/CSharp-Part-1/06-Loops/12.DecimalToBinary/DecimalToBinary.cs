//12. Decimal to Binary
//Description
//Using loops write a program that converts an integer number to its binary representation.
//    The input is entered as long. The output should be a variable of type string.
//    Do not use the built-in .NET functionality.
//Input
//    On the only input line you will receive the decimal integer number.
//Output
//    Output a single string - the representation of the input decimal number in it's binary representation.
//Constraints
//    All numbers will always be valid 32-bit integers.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Collections.Generic;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main()
        {
            long decimalNumber = long.Parse(Console.ReadLine());
            int numberLength = decimalNumber.ToString().Length;

            List<int> remainders = new List<int>();

            for (int i = 0; i < 32; i++)
            {
                if (decimalNumber % 2 == 0)
                {
                    remainders.Add(0);
                }
                else
                {
                    remainders.Add(1);
                }
                decimalNumber /= 2;
            }

            remainders.Reverse();

            for (int i = 0; i < remainders.Count; i++)
            {
                if (remainders[i] == 0)
                {
                    remainders.RemoveAt(0);
                    i = - 1;
                }
                else if (remainders[i] == 1)
                {
                    break;
                }
            }

            //string binaryNumber;       

            //while (decimalNumber > 0)
            //{
            //    int remainder = (int)decimalNumber % 2;
            //    binaryNumber = remainder + binaryNumber;
            //    decimalNumber /= 2;
            //}

            foreach (var binaryNumber in remainders)
            {
                Console.Write(binaryNumber);
            }
            Console.WriteLine();
        }
    }
}