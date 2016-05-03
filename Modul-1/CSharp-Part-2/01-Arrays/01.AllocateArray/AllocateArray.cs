using System;

namespace AllocateArray
{
    class AllocateArray
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(i * 5);
            }
        }
    }
}