//08. Numbers from 1 to N
//Description
//Write a program that reads an integer number N from the console and prints all the numbers in the interval[1, n], each on a single line.
//Input
//   On the only line you will receive the number N
//Output
//   You should print the numbers from 1 to N, each on a separate line
//Constraints
//    1 <= N< 1000
//    N will always be a valid integer number
//   Time limit: 0.1s
//   Memory limit: 8MB

using System;

namespace NumbersToN
{
    class NumbersToN
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}