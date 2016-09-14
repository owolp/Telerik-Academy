namespace Assertions.Algorithms
{
    using System;
    using System.Diagnostics;

    public class Sort
    {
        private const string ObjectCannotBeNull = "The provided {0} cannot be null.";
        private const string ValueCannotBeNegative = "The {0} index cannot be negative or equal to 0.";

        public static void SelectionSort<T>(T[] arr)
            where T : IComparable<T>
        {
            if (arr == null)
            {
                throw new ArgumentNullException(string.Format(ObjectCannotBeNull, "array"));
            }

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, string.Format(ObjectCannotBeNull, "array"));
            Debug.Assert(startIndex >= 0, string.Format(ValueCannotBeNegative, "start"));
            Debug.Assert(endIndex >= 0, string.Format(ValueCannotBeNegative, "end"));
            Debug.Assert(startIndex < endIndex, "The start index cannot be more than the end index.");
            Debug.Assert(endIndex <= int.MaxValue, $"The end index cannot be more than {int.MaxValue}.");
            Debug.Assert(endIndex <= arr.Length - 1, "The end index cannot be more than the array length.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T firstItem, ref T secondItem)
        {
            Debug.Assert(firstItem != null, string.Format(ObjectCannotBeNull, "first item"));
            Debug.Assert(firstItem != null, string.Format(ObjectCannotBeNull, "second item"));

            T oldX = firstItem;
            firstItem = secondItem;
            secondItem = oldX;
        }
    }
}
