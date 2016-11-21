using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class Task06
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine($"Before: {string.Join(", ", numbers)}");
            IDictionary<int, int> uniqueNumbers = new Dictionary<int, int>();

            // This one works too
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    if (uniqueNumbers.ContainsKey(numbers.ElementAt(i)))
            //    {
            //        uniqueNumbers[numbers.ElementAt(i)]++;
            //    }
            //    else
            //    {
            //        uniqueNumbers.Add(numbers.ElementAt(i), 1);
            //    }
            //}

            var query = numbers.GroupBy(r => r)
                .Select(grp => new
                {
                    Value = grp.Key,
                    Count = grp.Count()
                });

            foreach (var uniqueNumber in query)
            {
                if (uniqueNumber.Count % 2 != 0)
                {
                    numbers.RemoveAll(x => x == uniqueNumber.Value);
                }
            }

            Console.WriteLine($"After: {string.Join(", ", numbers)}");
        }
    }
}