using System;
using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    public class Task01
    {
        public static void Main()
        {
            ICollection<int> elements = new List<int>();
            Console.WriteLine("Please integer numbers, blank line to stop");
            var readLine = Console.ReadLine();

            while (true)
            {
                if (readLine == string.Empty)
                {
                    break;
                }

                int number;
                int.TryParse(readLine, out number);
                elements.Add(number);

                readLine = Console.ReadLine();
            }

            Console.WriteLine($"Average: {elements.Average()}");
            Console.WriteLine($"Sum: {elements.Sum()}");
        }
    }
}