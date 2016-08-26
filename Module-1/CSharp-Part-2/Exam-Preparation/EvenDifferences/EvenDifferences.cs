namespace EvenDifferences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EvenDifferences
    {
        static void Main()
        {
            Console.WriteLine(FindEvenSum(FindEvenDiff(ReadInput(Console.ReadLine()))));
        }

        static long[] ReadInput(string input)
        {
            return input.Split(' ').Select(long.Parse).ToArray();
        }

        static long FindAbsoluteDiff(long firstNumber, long secondNumber)
        {
            return Math.Abs(firstNumber - secondNumber);
        }

        static List<long> FindEvenDiff(long[] numbers)
        {
            List<long> evenDiff = new List<long>();

            int position = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                long currentNumber = numbers[position];
                long previousNumber = numbers[position - 1];

                long absDiff = FindAbsoluteDiff(currentNumber, previousNumber);

                if (absDiff % 2 == 0) // even
                {
                    evenDiff.Add(absDiff);
                    position += 2;
                }
                else // odd
                {
                    position += 1;
                }

                if (position >= numbers.Length)
                {
                    break;
                }
            }

            return evenDiff;
        }

        static long FindEvenSum(List<long> evenNumbers)
        {
            long evenSum = 0;

            foreach (long evenDigit in evenNumbers)
            {
                evenSum += evenDigit;
            }

            return evenSum;
        }
    }
}