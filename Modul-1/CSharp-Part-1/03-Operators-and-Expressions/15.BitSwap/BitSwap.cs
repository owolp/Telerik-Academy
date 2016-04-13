//15. BitSwap
//Description
//Write a program first reads 3 numbers n, p, q and k and than swaps bits { p, p+1, …, p+k-1}
//with bits { q, q+1, …, q+k-1}
//of n.Print the resulting integer on the console.
//Input
//On the only four lines of the input you will receive the integers n, p, q and k in this order.
//Output
//Output a single value - the value of n after the bit swaps.
//Constraints
//The first and the second sequence of bits will never overlap.
//n will always be a valid 32-bit positive integer.
//Time limit: 0.1s
//Memory limit: 8MB

using System;

namespace BitSwap
{
    class BitSwap
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            uint[] pArray = new uint[k];
            uint[] qArray = new uint[k];

            for (int i = p, j = 0; j < k; i++, j++)
            {
                pArray[j] = GetBit(n, i);
            }

            for (int i = q, j = 0; j < k; i++, j++)
            {
                qArray[j] = GetBit(n, i);
            }

            for (int i = p, j = 0; j < k; j++, i++)
            {
                n = SetBit(n, i, (int)qArray[j]);
            }

            for (int i = q, j = 0; j < k; j++, i++)
            {
                n = SetBit(n, i, (int)pArray[j]);
            }

            Console.WriteLine(n);
        }

        public static uint GetBit(uint number, int position)
        {
            uint mask = 1U << position;
            uint bit = number & mask;
            bit = bit >> position;

            return bit;
        }

        public static uint SetBit(uint number, int position, int bit)
        {
            if (bit == 0)
            {
                uint mask = ~(1U << position);
                number = number & mask;
                return number;
            }
            else // bit == 1
            {
                uint mask = 1U << position;
                number = number | mask;
                return number;
            }
        }
    }
}