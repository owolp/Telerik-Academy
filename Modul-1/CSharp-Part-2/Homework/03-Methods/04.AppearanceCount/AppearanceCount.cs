using System;
using System.Linq;

namespace AppearanceCount
{
    class AppearanceCount
    {
        static void Main()
        {
            Console.ReadLine();

            int[] numbers = StringToIntArray(Console.ReadLine());

            int specialNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(CheckNumberAppearance(numbers, specialNumber));
        }

        static int[] StringToIntArray(string arrNumbers)
        {
            int[] numbers = arrNumbers.Split(' ').Select(int.Parse).ToArray();

            return numbers;
        }

        static int CheckNumberAppearance(int[] numbers, int specialNumber)
        {
            int count = 0;

            foreach (int number in numbers)
            {
                if (number == specialNumber)
                {
                    count++;
                }
            }

            return count;
        }
    }
}