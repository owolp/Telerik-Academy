using System;
using System.Collections.Generic;

namespace QuadronacciRectangle
{
    class QuadronacciRectangle
    {
        static void Main()
        {
            List<long> numbers = new List<long>();

            for (int i = 0; i < 4; i++)
            {
                var number = long.Parse(Console.ReadLine());
                numbers.Add(number);
            }

            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int index = 4;

            for (int i = 0; i < r * c; i++)
            {
                var number = numbers[index - 1] + numbers[index - 2] + numbers[index - 3] + numbers[index - 4];
                numbers.Add(number);
                index++;

            }

            index = 0;
            for (int row = 0; row < r; row++)
            {
                for (int col = 0; col < c; col++)
                {
                    Console.Write(numbers[index] + " ");
                    index++;
                }
                Console.WriteLine();
            }
        }
    }
}