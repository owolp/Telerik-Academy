//04. Multiplication sign
//Description
//Write a program that shows the sign(+, - or 0) of the product of three real numbers, without calculating it.
//   Use a sequence of if operators.
//Input
//   On the first three lines, you will receive the three numbers, each on a separate line
//Output
//    Output a single line - the sign of the product of the three numbers
//Constraints
//    The input will always consist of valid floating-point numbers
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;

namespace MultiplicationSign
{
    class MultiplicationSign
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

            string result;
            if ((a == 0) | (b == 0) | (c == 0))
            {
                result = "0";
            }
            else if ((a < 0) & (b > 0) & (c > 0))
            {
                result = "-";
            }
            else if ((a > 0) & (b < 0) & (c > 0))
            {
                result = "-";
            }
            else if ((a > 0) & (b > 0) & (c < 0))
            {
                result = "-";
            }
            else if ((a < 0) & (b < 0) & (c < 0))
            {
                result = "-";
            }
            else
            {
                result = "+";
            }

            Console.WriteLine(result);
        }
    }
}