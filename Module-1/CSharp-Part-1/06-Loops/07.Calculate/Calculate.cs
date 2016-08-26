//07. Calculate 3!
//Description
//In combinatorics, the number of ways to choose N different members out of a group of N different elements(also known as the number of combinations)
//is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
//Your task is to write a program that calculates N! / (K! * (N - K)!) for given N and K.
//  Try to use only two loops.
//Input
//  On the first line, there will be only one number - N
//  On the second line, there will also be only one number - K
//Output
//  On the only output line, write the result of the calculation for the provided N and K
//Constraints
//    1 < K<N< 100
//        Hint: overflow is possible
//  Time limit: 0.1s
//  Memory limit: 16MB

using System;
using System.Numerics;

namespace Calculate
{
    class Calculate
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int sumNK = n - k;
            BigInteger factorialN = 1;
            BigInteger factorialK = 1;
            BigInteger factorialNK = 1;

            for (int i = 2; i <= n; i++)
            {
                if (k >= i)
                {
                    factorialK *= i;
                }

                factorialN *= i;

                if (sumNK >= i)
                {
                    factorialNK *= i;
                }
            }

            BigInteger calculation = factorialN / (factorialK * factorialNK);

            Console.WriteLine(calculation);
        }
    }
}