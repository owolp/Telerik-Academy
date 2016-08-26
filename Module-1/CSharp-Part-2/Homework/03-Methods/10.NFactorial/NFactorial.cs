using System;
using System.Numerics;

namespace NFactorial
{
    class NFactorial
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFactorial(CreateArray(n)));

        }

        static int[] CreateArray(int n)
        {
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            return numbers;
        }

        static BigInteger CalculateFactorial(int[] numbers)
        {
            BigInteger factorial = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                factorial *= numbers[i];
            }

            return factorial;
        }
    }
}