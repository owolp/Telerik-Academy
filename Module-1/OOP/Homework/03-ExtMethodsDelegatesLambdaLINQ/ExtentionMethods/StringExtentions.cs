namespace ExtentionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class StringExtentions
    {
        public static string LongestString(this List<string> collection)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            string longestString = collection[0];

            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i].Length > longestString.Length)
                {
                    longestString = collection[i];
                }
            }

            return longestString;
        }
    }
}
