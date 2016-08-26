//Rectangles
//Description
//Write an expression that calculates rectangle’s perimeter and area by given width and height.The width and height should be read from the console.
//Input
//   The input will consist of 2 lines:
//        On the first line, you will receive a floating-point number that will represent the width of the rectangle.
//       On the second line, you will receive another floating-point number that will represent the height of the rectangle.
//Output
//   Output a single line - the rectangle's perimeter and area, separated by a whitespace.
//       Print the perimeter and area values with exactly 2-digits precision after the floating point
// Edit: BGCoder expects the area first and on second place the perimeter.
//Constraints
//   The width and height will always be valid floating-point numbers.
//   Time limit: 0.1s
//   Memory limit: 8MB

using System;
using System.Threading;
using System.Globalization;

namespace Rectangles
{
    class Rectangles
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            double width = double.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double height = double.Parse(line);

            double perimeter = 2 * (width + height);
            double area = width * height;

            Console.WriteLine("{0:F2} {1:F2}", area, perimeter);
        }
    }
}