using System;

namespace BinarySearch
{
    class BinarySearch
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int x = int.Parse(Console.ReadLine());

            int position = -1;

            int start = 0;
            int end = n - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (x > numbers[middle])
                {
                    start = middle + 1;
                }
                else if (x < numbers[middle])
                {
                    end = middle - 1; 
                }
                else // x = middle
                {
                    position = middle;
                    break;
                }
            }

            Console.WriteLine(position);
        }
    }
}