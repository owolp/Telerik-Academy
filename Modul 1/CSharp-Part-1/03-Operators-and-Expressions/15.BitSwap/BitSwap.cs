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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSwap
{
    class BitSwap
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            byte[] array = new byte[32];
        }
    }
}
