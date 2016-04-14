//17. Spiral Matrix
//Description
//Write a program that reads from the console a positive integer number N(1 ≤ N ≤ 20) and prints a matrix holding the numbers from 1 to N* N in the form of square spiral like in the examples below.
//Input
//    The input will always consist of a single line containing a single number - N.
//Output
//    Output a spiral matrix as described below.
//Constraints
//    N will always be a valid integer number.
//    1 ≤ N ≤ 20
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int[,] numberArray = new int[number, number];
            int row = 0;
            int col = 0;
            int counter = 1;
            int steps = number;
            int cycles = 0;

            while (counter <= number * number)
            {
                for (int i = 0; i < steps; i++)
                {
                    col = i + cycles;
                    numberArray[row, col] = counter;
                    counter++;
                }
                steps--;

                for (int i = 1; i <= steps; i++)
                {
                    row = i + cycles;
                    numberArray[row, col] = counter;
                    counter++;
                }
                steps--;

                for (int i = steps; i >= 0; i--)
                {
                    col = i + cycles;
                    numberArray[row, col] = counter;
                    counter++;
                }

                for (int i = steps; i > 0; i--)
                {
                    row = i + cycles;
                    numberArray[row, col] = counter;
                    counter++;
                }
                cycles++;
            }

            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {

                    Console.Write(j == number + i - 1 ? "{0}" : "{0} ", numberArray[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}