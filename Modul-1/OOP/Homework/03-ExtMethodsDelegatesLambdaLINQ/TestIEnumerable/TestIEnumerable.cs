namespace TestIEnumerable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ExtentionMethods;

    public class TestIEnumerable
    {
        public static void Main()
        {
            var numbers = new List<int>();

            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(random.Next(-20, 20));
            }

            Console.WriteLine("Printing the list:");
            Console.WriteLine("\t{0}", string.Join(", ", numbers));
            Console.WriteLine();

            Console.WriteLine("The sum of the items is:");
            Console.WriteLine("\t{0}", numbers.Sum());
            Console.WriteLine();

            Console.WriteLine("The product of the items is:");
            Console.WriteLine("\t{0}", numbers.Product());
            Console.WriteLine();

            Console.WriteLine("The min element from the items is:");
            Console.WriteLine("\t{0}", numbers.Min());
            Console.WriteLine();

            Console.WriteLine("The max element from the items is:");
            Console.WriteLine("\t{0}", numbers.Max());
            Console.WriteLine();

            Console.WriteLine("The average of the items is:");
            Console.WriteLine("\t{0}", numbers.Average());
            Console.WriteLine();
        }
    }
}
