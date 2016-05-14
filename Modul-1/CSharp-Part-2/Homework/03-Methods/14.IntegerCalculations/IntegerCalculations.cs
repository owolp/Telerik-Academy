using System;
using System.Linq;

namespace IntegerCalculations
{
    class IntegerCalculations
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int minNumber = GetMinNumber(numbers);
            int maxNumber = GetMaxNumber(numbers);
            double averageValue = GetAverageValue(numbers);
            int sumValue = GetSumValue(numbers);
            long productValue = GetProductValue(numbers);

            Console.WriteLine(minNumber);
            Console.WriteLine(maxNumber);
            Console.WriteLine("{0:F2}", averageValue);
            Console.WriteLine(sumValue);
            Console.WriteLine(productValue);

        }

        static int GetMinNumber(int[] numbers)
        {
            int minNumber = int.MaxValue;

            foreach (int number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }

        static int GetMaxNumber(int[] numbers)
        {
            int maxNumber = int.MinValue;

            foreach (int number in numbers)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            return maxNumber;
        }

        static double GetAverageValue(int[] numbers)
        {
            double average = 0;

            foreach (int number in numbers)
            {
                average += number;
            }

            average /= numbers.Length;

            return average;
        }

        static int GetSumValue(int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        static long GetProductValue(int[] numbers)
        {
            long product = 1;

            foreach (int number in numbers)
            {
                product *= number;
            }

            return product;
        }
    }
}