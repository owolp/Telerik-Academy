namespace Assertions.Algorithms
{
    using System;
    using System.Diagnostics;

    public class Search
    {
        private const string ObjectCannotBeNull = "The provided {0} cannot be null.";
        private const string ValueCannotBeNegative = "The {0} index cannot be negative or equal to 0.";

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            // 01. Defensive-Programming-and-Exceptions Presentation
            // Consider using exceptions for public methods and assertions for private
            if (arr == null)
            {
                throw new ArgumentNullException(string.Format(ObjectCannotBeNull, "array"));
            }

            if (value == null)
            {
                throw new ArgumentNullException(string.Format(ObjectCannotBeNull, "value"));
            }

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) where T : IComparable<T>
        {
            Debug.Assert(arr != null, string.Format(ObjectCannotBeNull, "array"));
            Debug.Assert(value != null, string.Format(ObjectCannotBeNull, "value"));
            Debug.Assert(startIndex >= 0, string.Format(ValueCannotBeNegative, "start"));
            Debug.Assert(endIndex >= 0, string.Format(ValueCannotBeNegative, "end"));
            Debug.Assert(startIndex < endIndex, "The start index cannot be more than the end index.");
            Debug.Assert(endIndex <= int.MaxValue, $"The end index cannot be more than {int.MaxValue}.");
            Debug.Assert(endIndex <= arr.Length - 1, "The end index cannot be more than the array length.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                else if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}