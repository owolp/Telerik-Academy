using System;
using System.Collections.Generic;
using System.Linq;

namespace Task08
{
    public class Task08
    {
        public static void Main()
        {
            int[] numbers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
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
                var n = numbers.Count();
                var isTrue = ((n / 2) + 1) <= uniqueNumber.Count;
                if (isTrue)
                {
                    Console.WriteLine($"The number {uniqueNumber.Value} occurs {uniqueNumber.Count} times");
                }      
            }
        }
    }
}
