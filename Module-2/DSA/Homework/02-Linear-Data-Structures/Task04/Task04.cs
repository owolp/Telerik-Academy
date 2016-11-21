using System;
using System.Collections.Generic;
using System.Linq;

namespace Task04
{
    public class Task04
    {
        public static void Main()
        {
            var numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 5, 5, 5 };
            Console.WriteLine($"Before: {string.Join(", ", numbers)}");

            var longestSubsequence = new List<int>();
            var currentSubsequence = new List<int> { numbers[0] };

            var longestLength = currentSubsequence.Count();
            var currentLength = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int currentElement = numbers.ElementAt(i);
                int nextElement = numbers.ElementAt(i + 1);

                if (currentElement == nextElement)
                {
                    currentSubsequence.Add(nextElement);
                    currentLength++;
                }
                else
                {
                    currentSubsequence.Clear();
                    currentSubsequence.Add(numbers[i + 1]);
                    currentLength = 0;
                }

                if (currentLength > longestLength)
                {
                    longestSubsequence.Clear();
                    longestSubsequence.AddRange(currentSubsequence);
                    longestLength = currentLength;
                }
            }

            Console.WriteLine($"After: {string.Join(", ", longestSubsequence)}");
        }
    }
}