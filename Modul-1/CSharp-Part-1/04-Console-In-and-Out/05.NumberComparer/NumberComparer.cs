//05. Number Comparer
//Description
//Write a program that gets two numbers from the console and prints the greater of them.
//Input
//    On the first two lines you will receive the two numbers, A and B
//Output
//    On the only line print the larger of the two numbers
//        * Try implementing it without using if-statements
// Constraints
//    The input will always be valid and in the described format.
//    The numbers A and B will always be valid real number
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;
using System.Threading;
using System.Globalization;

namespace NumberComparer
{
    class NumberComparer
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

            //double greater = Math.Max(a, b);
            //Console.WriteLine(greater);
            Console.WriteLine( (a > b) ? a : b);
        }
    }
}