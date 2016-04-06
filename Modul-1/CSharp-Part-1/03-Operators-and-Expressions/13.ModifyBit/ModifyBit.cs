//Modify Bit
//Description
//We are given an integer number N(read from the console), a bit value v(read from the console as well) (v = 0 or 1) and a position P(read from the console). Write a sequence of operators(a few lines of C# code) that modifies N to hold the value v at the position P from the binary representation of N while preserving all other bits in N. Print the resulting number on the console.
//Input
//    The input will consist of exactly 3 lines containing the following:
//        First line - the integer number N.
//        Second line - the position P.
//        Third line - the bit value v.
//Output
//    Output a single line containing the value of the number N with the modified bit.
//Constraints
//    N will always be a valid 64-bit positive integer.
//    P will always be between in the range [0, 64).
//    v will be always either 0 or 1.
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace ModifyBit
{
    class ModifyBit
    {
        static void Main()
        {
            ulong number = uint.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int value = int.Parse(Console.ReadLine());

            ulong result;

            if (value == 0)
            {
                ulong mask = (ulong)~(1 << position);
                result = number & mask;
            }
            else
            {
                ulong mask = (ulong)1 << position;
                result = number | mask;
            }

            Console.WriteLine(result);
        }
    }
}