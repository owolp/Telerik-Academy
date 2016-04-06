//03. Circle
//Description
//Write a program that reads from the console the radius r of a circle and prints its perimeter and area, rounded and formatted with 2 digits after the decimal point.
//Input
//    On the only line of the input you will receive the radius of the circle - r
//Output
//    You should print one line only: the perimeter and the area of the circle, separated by a whitespace, and with 2 digits precision
//Constraints
//    The radius r will always be a valid and positive real number
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;
using System.Threading;
using System.Globalization;

namespace Circle
{
    class Circle
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            double radius = double.Parse(line);

            double perimter = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine("{0:F2} {1:F2}", perimter, area);
        }
    }
}