//16. Trailing 0 in N!
//Description
//Write a program that calculates with how many zeros the factorial of a given number N has at its end.
//    Your program should work well for very big numbers, e.g.N = 100000.
//Input
//    On the only input line, you will receive a single integer - the number N
//Output
//    Output a single number - the count of trailing zeros for the N!
//Constraints
//    N will always be a valid positive integer number.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Numerics;

namespace Trailing
{
    class Trailing
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            int counter = 0;

            while (factorial % 10 == 0)
            {
                counter++;
                factorial /= 10;
            }
            Console.WriteLine(counter);
        }
    }
}