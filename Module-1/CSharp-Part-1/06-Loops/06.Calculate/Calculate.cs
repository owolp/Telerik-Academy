//06. Calculate Again
//Description
//Write a program that calculates N! / K! for given N and K.
//    Use only one loop.
//Input
//    On the first line, there will be only one number - N
//    On the second line, there will be only one number - K
//Output
//    Output a single line, consisting of the result from the calculation described above.
//Constraints
//    1 < K<N< 100
//        Hint: overflow is possible
//    N and K will always be valid integer numbers
//    Time limit: 0.1s
//    Memory limit: 16MB

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

            BigInteger factorialN = 1;
            BigInteger factorialK = 1;

            for (int i = 2; i <= n; i++)
            {
                if (k >= i)
                {
                    factorialK *= i;
                }

                factorialN *= i;
            }

            BigInteger calculation = factorialN / factorialK;

            Console.WriteLine(calculation);
        }
    }
}