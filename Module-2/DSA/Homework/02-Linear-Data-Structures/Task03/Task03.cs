using System;
using System.Collections.Generic;

namespace Task03
{
    public class Task03
    {
        public static void Main()
        {
            List<int> elements = new List<int>();
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

            elements.Sort();

            Console.WriteLine("Sorted array of numbers:");
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
