using System;
using System.Linq;

namespace SubIntegers
{
    class SubIntegers
    {
        static void Main()
        {
            Console.WriteLine(FindSum(Console.ReadLine()));
        }

        static int FindSum(string input)
        {
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}