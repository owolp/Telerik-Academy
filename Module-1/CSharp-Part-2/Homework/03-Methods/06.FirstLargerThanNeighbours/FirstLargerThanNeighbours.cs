using System;
using System.Linq;

namespace FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static void Main()
        {
            Console.ReadLine();

            int[] numbers = StringToIntArray(Console.ReadLine());

            Console.WriteLine(GetLargerIndex(numbers));

        }

        static int[] StringToIntArray(string arrNumbers)
        {
            int[] numbers = arrNumbers.Split(' ').Select(int.Parse).ToArray();

            return numbers;
        }

        static int GetLargerIndex(int[] numbers)
        {
            int number = -1;

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1])
                {
                    return i;
                }
            }

            return number;
        }
    }
}