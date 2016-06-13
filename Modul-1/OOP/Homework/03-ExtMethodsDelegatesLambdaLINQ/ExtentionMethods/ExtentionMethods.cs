namespace ExtentionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ExtentionMethods
    {
        #region Problem1
        // Problem 1. StringBuilder.Substring
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            SubstringValidation(sb, index, length);

            var result = new StringBuilder();
            for (int position = 0; position < length; position++)
            {
                result.Append(sb[index + position]);
            }

            return result;
        }

        public static void SubstringValidation(StringBuilder sb, int index, int length)
        {
            if (index > sb.Length)
            {
                throw new IndexOutOfRangeException("The provided index is out of range.");
            }

            if (index + length >= sb.Length)
            {
                throw new IndexOutOfRangeException("The provided index and length is out of range.");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("The index can not be a negative number.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("The length can not be a negative number.");
            }
        }
        #endregion

        #region Problem2
        // Problem 2. IEnumerable extensions
        public static T Sum<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            dynamic sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            dynamic product = 1;
            foreach (var item in collection)
            {
                product *= item;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            T minElement = collection.First();
            foreach (var item in collection)
            {
                if (minElement.CompareTo(collection) > 0)
                {
                    minElement = item;
                }
            }

            return minElement;
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            T maxElement = collection.First();
            foreach (var item in collection)
            {
                if (maxElement.CompareTo(item) < 0)
                {
                    maxElement = item;
                }
            }

            return maxElement;
        }

        public static T Average<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            dynamic sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }

            dynamic average = sum / collection.Count();

            return average;
        }
        #endregion
    }
}