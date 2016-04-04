//09. Sum of N Numbers
//Description
//Write a program that enters a number N and after that enters more N numbers and calculates and prints their sum.
//    Note: You may need to use a for-loop.
//Input
//    On the first line, you will receive the number N
//    On each of the next N lines, you will receive a floating-point number
//Output
//    On must output only one number - the sum of the N numbers
//Constraints
//    1 <= N <= 200
//    All numbers will be valid floating-point numbers in the range [-1000, 1000]
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;
using System.Threading;
using System.Globalization;

namespace SumOfNumbers
{
    class SumOfNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int quantity = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < quantity; i++)
            {
                var line = Console.ReadLine();
                line = line.Replace(',', '.');
                double number = double.Parse(line);

                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
