//06. Biggest of 5
//Description
//Write a program that finds the biggest of 5 numbers that are read from the console, using only 5 if statements.
//Input
//    On the first 5 lines you will receive the 5 numbers, each on a separate line
//Output
//    On the only output line, write the biggest of the 5 numbers
//Constraints
//    The 5 numbers will always be valid floating-point numbers in the range[-200, 200]
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;

namespace BiggestOfFive
{
    class BiggestOfFive
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

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double d = double.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double e = double.Parse(line);

            double biggestNumber;

            if ((a > b) && (a > c) && (a > d) && (a > e))
            {
                biggestNumber = a;
            }
            else if ((b > a) && (b > c) && (b > d) && (b > e))
            {
                biggestNumber = b;
            }
            else if ((c > a) && (c > b) && (c > d) && (c > e))
            {
                biggestNumber = c;
            }
            else if ((d > a) && (d > b) && (d > c) && (d > e))
            {
                biggestNumber = d;
            }
            else
            {
                biggestNumber = e;
            }

            Console.WriteLine(biggestNumber);
        }
    }
}