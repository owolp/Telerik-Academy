using System;

namespace SelectionSort
{
    class SelectionSort
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}