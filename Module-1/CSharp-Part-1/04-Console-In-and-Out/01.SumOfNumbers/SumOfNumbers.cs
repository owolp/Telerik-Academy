//01. Sum of 3 numbers
//Description
//Write a program that reads 3 real numbers from the console and prints their sum.
//Input
//    On the first line, you will receive the number a
//    On the second line, you will receive the number b
//    On the third line, you will receive the number c
//Output
//Your output should consist only of a single line - the sum of the three numbers.
//Constraints
//    a, b and c will always be valid real numbers between -1000 and 1000, inclusive
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

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            double a = double.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double b = double.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double c = double.Parse(line);

            double sum = a + b + c;

            Console.WriteLine(sum);
        }
    }
}