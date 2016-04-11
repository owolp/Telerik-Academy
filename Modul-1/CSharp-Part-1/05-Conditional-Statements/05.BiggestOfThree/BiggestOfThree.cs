﻿//05. Biggest of 3
//Description
//Write a program that finds the biggest of three numbers that are read from the console.
//Input
//    On the first three lines you will receive the three numbers, each on a separate line.
//Output
//    On the only output line, write the biggest of the three numbers.
//Constraints
//    The three numbers will always be valid floating-point numbers in the range [-200, 200].
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;

namespace BiggestOfThree
{
    class BiggestOfThree
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

            double biggestNumber = Math.Max(a, b);
            biggestNumber = Math.Max(biggestNumber, c);

            Console.WriteLine(biggestNumber);
        }
    }
}