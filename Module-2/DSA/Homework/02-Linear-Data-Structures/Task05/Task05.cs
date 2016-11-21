using System;
using System.Collections.Generic;

namespace Task05
{
    public class Task05
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 4, 2, -2, 5, 2, -3, 2, -3, 1, 5, -2, 5, -5, 5 };

            Console.WriteLine($"Before: {string.Join(", ", numbers)}");

            numbers.RemoveAll(n => n < 0);

            Console.WriteLine($"After: {string.Join(", ", numbers)}");
        }
    }
}