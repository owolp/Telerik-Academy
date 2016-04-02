//06. Quadratic Equation
//Description
//Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it(prints its real roots).
//Input
//    On the first three lines, you will receive the coefficients a, b, and c, each on a separate line in the same order
//Output
//    If two different real roots exist, print them on two separate lines
//        Print the smaller root on the first line
//    If only one real root exists, print it on the only output line
//    If no real root exists, print the string "no real roots"
//    The roots, should they exist, must be printed with precision exactly two digits after the floating point
//Constraints
//    The input will always consist of valid real numbers in the range[-1000, 1000] and will follow the described format
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;
using System.Threading;
using System.Globalization;

namespace QuadraticEquation
{
    class QuadraticEquation
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

            double discriminant = Math.Pow(b, 2) - (4 * a * c);
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            if (discriminant > 0)
            {
                double smaller = Math.Min(x1, x2);
                double greater = Math.Max(x1, x2);
                Console.WriteLine("{0:F2}", smaller);
                Console.WriteLine("{0:F2}", greater);
                return;
            }
            else if (discriminant == 0)
            {
                Console.WriteLine("{0:F2}", x1);
                return;
            }
            else
            {
                Console.WriteLine("no real roots");
                return;
            }      
        }
    }
}