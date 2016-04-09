//07. Sum of 5 numbers
//Description
//Write a program that reads 5 integer numbers from the console and prints their sum.
//Input
//You will receive 5 numbers on five separate lines.
//Output
//Your output should consist only of a single line - the sum of the 5 numbers.
//Constraints
//    All 5 numbers will always be valid integer numbers between -1000 and 1000, inclusive
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace Sum
{
    class Sum
    {
        static void Main()
        {
            byte totalNumbers = 5;
            int[] numbers = new int[totalNumbers];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}