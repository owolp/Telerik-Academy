//N-th Bit
//Description
//Write a program that reads from the console two integer numbers P and N and prints on the console the value of P's N-th bit.
//Input
//    On the first line you will receive the number P.On the second line you will receive the number N.
//Output
//   Output a single value - the value of the N-th bit in P.
//Constraints
//   N will be a positive integer and always smaller than 55.
//    P will always be in the range [0, 2<sup>55</sup>).
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;
using System.Numerics;

namespace NthBit
{
    class NthBit
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            BigInteger mask = 1 << p;
            BigInteger nMask = n & mask;
            BigInteger bit = nMask >> p;
            Console.WriteLine(bit);
        }
    }
}