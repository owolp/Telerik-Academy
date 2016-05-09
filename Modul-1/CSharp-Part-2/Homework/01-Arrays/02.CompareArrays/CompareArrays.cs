using System;

namespace CompareArrays
{
    class CompareArrays
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                firstArray[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                secondArray[i] = int.Parse(Console.ReadLine());
            }

            bool equal = true;

            for (int i = 0; i < n; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    equal = false;
                    break;
                }
            }

            Console.WriteLine(equal == true ? "Equal" : "Not equal");
        }
    }
}