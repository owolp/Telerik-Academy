//07. Sort 3 Numbers
//Description
//Write a program that enters 3 real numbers and prints them sorted in descending order.
//    Use nested if statements.
//    Don’t use arrays and the built-in sorting functionality.
//Input
//    On the first three lines, you will receive the three numbers, each on a separate line.
//Output
//    Output a single line on the console - the sorted numbers, separated by a whitespace
//Constraints
//    The three numbers will always be valid integer numbers in the range [-1000, 1000]
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;

namespace SortThreeNumbers
{
    class SortThreeNumbers
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

            if (a > b)
            {
                if (a > c)
                {
                    if (b > c)
                    {
                        Console.WriteLine("{0} {1} {2}", a, b, c);
                    }
                    else // c > b
                    {
                        Console.WriteLine("{0} {1} {2}", a, c, b);
                    }
                }
                else // a < c
                {
                    Console.WriteLine("{0} {1} {2}", c, a, b);
                }
            }
            else // a < b
            {
                if (b > c)
                {
                    if (a > c)
                    {
                        Console.WriteLine("{0} {1} {2}", b, a, c);
                    }
                    else // c > a
                    {
                        Console.WriteLine("{0} {1} {2}", b, c, a);
                    }
                }
                else // c > b
                {
                    Console.WriteLine("{0} {1} {2}", c, b, a);
                }
            }
        }
    }
}