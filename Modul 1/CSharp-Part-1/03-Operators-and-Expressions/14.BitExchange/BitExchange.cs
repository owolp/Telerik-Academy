//14. BitExchange
//Description
//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer(read from the console).
//Input
//    On the only input line you will receive the unsigned integer number whose bits you must exchange.
//Output
//    On the only output line print the value of the integer with the exchanged bits.
//Constraints
//    N will always be a valid 32-bit unsigned integer.
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace BitExchange
{
    class BitExchange
    {
        static void Main()
        {
            uint number = uint.Parse(Console.ReadLine());

            uint[] array = new uint[6];
            for (int i = 0, j = 3; i < array.Length; i++, j++)
            {
                uint mask = (uint)(1 << j);
                uint numberMask = number & mask;
                uint bit = numberMask >> j;
                array[i] = bit;
                if (i == 2)
                {
                    j = 23;
                }
            }

            uint result = 0;
            int position = 24;
            if (array[0] == 0)
            {
                uint mask = (uint)(~(1 << position));
                result = number & mask;
            }
            else
            {
                uint mask = (uint)(1 << position);
                result = number | mask;
            }
            
            for (int i = 1, p = 25; i < array.Length; i++, p++)
            {
                if (array[i] == 0)
                {
                    uint mask = (uint)(~(1 << p));
                    result = result & mask;
                }
                else
                {
                    uint mask = (uint)(1 << p);
                    result = result | mask;
                }

                if (p == 26)
                {
                    p = 2;
                }
            }
            Console.WriteLine(result);
        }
    }
}