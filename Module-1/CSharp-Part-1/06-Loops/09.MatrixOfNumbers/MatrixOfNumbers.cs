//09. Matrix of Numbers
//Description
//Write a program that reads from the console a positive integer number N and prints a matrix like in the examples below.Use two nested loops.
//   Challenge: achieve the same effect without nested loops
//Input
//   The input will always consist of a single line, which contains the number N
//Output
//   See the examples.
//Constraints
//    1 <= N <= 20
//    N will always be a valid integer number
//   Time limit: 0.1s
//   Memory limit: 16MB

using System;

namespace MatrixOfNumbers
{
    class MatrixOfNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = i; j < (number + i); j++)
                {
                    Console.Write(j == number + i - 1 ? "{0}" : "{0} ", j);
                }
                Console.WriteLine();
            }        
        }
    }
}