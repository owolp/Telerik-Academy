using System;
using System.Linq;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n - 1];

            // fill in the initial array with all numbers
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 2;
            }

            // start remove the non prime numbers
            var start = 0;
            var plus = 2;

            for (int j = 0; j < Math.Sqrt(numbers.Length); j++)
            {
                for (int i = start; i < numbers.Length; i += plus)
                {
                    if (i != start && numbers[i] != 0)
                    {
                        numbers[i] = 0;
                    }
                }

                for (int i = start; i < numbers.Length; i++)
                {
                    if (i != start && numbers[i] != 0)
                    {
                        start = numbers[i] - 2;
                        plus = i + 2;
                        break;
                    }
                }
            }

            // get max value with System.Linq
            Console.WriteLine(numbers.Max());
        }
    }
}
