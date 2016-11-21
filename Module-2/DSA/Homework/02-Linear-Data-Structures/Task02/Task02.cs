using System;
using System.Collections.Generic;

namespace Task02
{
    public class Task02
    {
        public static void Main()
        {
            int n = 5;
            Console.WriteLine($"Please enter {n} numbers:");

            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}