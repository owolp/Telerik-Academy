namespace DivisibleBy7And3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DivisibleBy7And3
    {
        public static void Main()
        {
            // Problem 6. Divisible by 7 and 3
            Random random = new Random();
            int[] numbers = new int[100];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 100);
            }

            List<int> divisibleBy7And3 = numbers.Where(n => n % 7 == 0 && n % 3 == 0).ToList();

            Console.WriteLine("Problem 6. Divisible by 7 and 3");
            Console.WriteLine("\t" + string.Join(", ", divisibleBy7And3));
        }
    }
}
