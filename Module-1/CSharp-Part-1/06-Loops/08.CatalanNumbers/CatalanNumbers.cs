//08. Catalan Numbers
//Description
//In combinatorics, the Catalan numbers are calculated by the following formula: Catalan-formula
//https://cloud.githubusercontent.com/assets/3619393/5626137/d7ec8bc2-958f-11e4-9787-f6c386847c81.png
//    Write a program to calculate the Nth Catalan number by given N
//Input
//    On the only line, you will receive the number N
//Output
//    Output a single number - the Nth Catalan number
//Constraints
//    N will always be a valid integer number in the range[0, 100]
//        Hint: overflow is possible.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Numerics;

namespace CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            BigInteger fact2N = 2;
            BigInteger factNPlus1 = 2;
            BigInteger factN = 1;

            for (int i = 2; i <= (2 * n); i++)
            {
                if (i <= (n + 1))
                {
                    factNPlus1 *= i;
                }

                if (i <= n)
                {
                    factN *= i;
                }

                fact2N *= i;
            }

            BigInteger catalanNumber = fact2N / (factNPlus1 * factN);
            Console.WriteLine(catalanNumber);
        }
    }
}