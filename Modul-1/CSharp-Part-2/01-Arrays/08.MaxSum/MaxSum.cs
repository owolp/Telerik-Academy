using System;

namespace MaxSum
{
    class MaxSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int bestSum = 0;

            for (int i = 0; i < n; i++)
            {
                var currentSum = 0;
                for (int j = i; j < n; j++)
                {
                    currentSum += numbers[j];
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                    }
                }
            }

            Console.WriteLine(bestSum);
        }
    }
}