namespace ExtentionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtentions
    {
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
    }
}