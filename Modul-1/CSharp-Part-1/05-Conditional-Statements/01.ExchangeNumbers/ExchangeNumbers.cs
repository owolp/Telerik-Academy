//01. Exchange numbers
//Description
//Write a program that reads two double values from the console A and B, stores them in variables and exchanges their values if the first one is greater than the second one.
//Use an if-statement.As a result print the values of the variables A and B, separated by a space.
//Input
//  On the first line, you will receive the value of A
//  On the second line, you will receive the value of B
//Output
//    On the only output line, print the values of the two variables, separated by a whitespace
//Constraints
//    A and B will always be valid real numbers between -100 and 100
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;

namespace ExchangeNumbers
{
    class ExchangeNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            double numberA = double.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double numberB = double.Parse(line);

            if (numberA > numberB)
            {
                double temp = numberA;
                numberA = numberB;
                numberB = temp;
            }

            Console.WriteLine("{0} {1}", numberA, numberB);
        }
    }
}