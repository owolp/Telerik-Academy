using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingArray
{
    class SortingArray
    {
        static void Main()
        {
            Console.ReadLine();

            List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int[] reversedArr = ReverseArray(OrderArray(arr));

            Console.WriteLine(string.Join(" ", reversedArr));
        }

        static int GetMaxNumber(List<int> arr)
        {
            int maxValue = arr[0];
            int index = 0;

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] >= maxValue)
                {
                    maxValue = arr[i];
                    index = i;
                }
            }

            arr.RemoveAt(index);
            return maxValue;
        }

        static int[] ReverseArray(List<int> arr)
        {
            int[] reversedArr = new int[arr.Count];

            int index = arr.Count - 1;

            for (int i = 0; i < arr.Count; i++)
            {
                reversedArr[index] = arr[i];
                index--;
            }

            return reversedArr;
        }

        static List<int> OrderArray(List<int> arr)
        {
            List<int> orderedArr = new List<int>();

            int arrLength = arr.Count;

            for (int i = 0; i < arrLength; i++)
            {
                orderedArr.Add(GetMaxNumber(arr));
            }

            return orderedArr;
        }
    }
}