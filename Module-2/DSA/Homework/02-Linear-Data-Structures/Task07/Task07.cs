using System;
using System.Collections.Generic;
using System.Linq;

namespace Task07
{
    public class Task07
    {
        public static void Main()
        {
            int[] numbers = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine($"Before: {string.Join(", ", numbers)}");
            IDictionary<int, int> uniqueNumbers = new Dictionary<int, int>();

            var query = numbers.GroupBy(r => r)
                .Select(grp => new
                {
                    Value = grp.Key,
                    Count = grp.Count()
                });

            foreach (var uniqueNumber in query)
            {
                Console.WriteLine($"The number {uniqueNumber.Value} occurs {uniqueNumber.Count} times");
            }
        }
    }
}
