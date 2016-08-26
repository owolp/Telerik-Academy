using System;
using System.Linq;

namespace LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static void Main()
        {
            Console.ReadLine();

            int[] numbers = StringToIntArray(Console.ReadLine());

            Console.WriteLine(GetLargerNumberFromNeighbours(numbers));
        }

        static int[] StringToIntArray(string arrNumbers)
        {
            int[] numbers = arrNumbers.Split(' ').Select(int.Parse).ToArray();

            return numbers;
        }

        static int GetLargerNumberFromNeighbours(int[] numbers)
        {
            int count = 0;

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1])
                {
                    count++;
                }
            }

            return count;
        }

    }
}