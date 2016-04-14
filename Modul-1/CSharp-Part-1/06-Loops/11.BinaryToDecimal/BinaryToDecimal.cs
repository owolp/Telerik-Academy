//11. Binary to Decimal
//Description
//Using loops write a program that converts a binary integer number to its decimal form.
//    The input is entered as string. The output should be a variable of type long.
//    Do not use the built-in .NET functionality.
//Input
//    You will receive exactly one line containing an integer number representation in binary
//Output
//    On the only output line write the decimal representation of the number
//Constraints
//    All input numbers will be valid 32-bit integers
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            var decimalNumber = Console.ReadLine();

            int[] decimalAsIntArray = new int[decimalNumber.Length];

            for (int i = 0; i < decimalAsIntArray.Length; i++)
            {
                var decimalAsString = decimalNumber[decimalAsIntArray.Length - i - 1].ToString();
                decimalAsIntArray[i] = Convert.ToInt32(decimalAsString);
            }

            long binaryNumber = 0;
            for (int i = 0; i < decimalAsIntArray.Length; i++)
            {
                int twoPower = (int)Math.Pow(2, i);
                if (decimalAsIntArray[i] != 0)
                {
                    binaryNumber += twoPower;
                }
            }

            Console.WriteLine(binaryNumber);
        }
    }
}