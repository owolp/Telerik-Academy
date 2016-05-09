using System;

namespace MaxKSum
{
    class MaxKSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);

            int sum = 0;

            for (int i = n - 1; i >= n - k; i--)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }
    }
}