//Point, Circle, Rectangle
//Description
//Write a program that reads a pair of coordinates x and y and uses an expression to checks for given point(x, y) if it is within the circle K({ 1, 1}, 1.5) 
//and out of the rectangle R(top= 1, left= -1, width= 6, height= 2).
//Input
//    You will receive the pair of coordinates on the two lines of the input - on the first line you will find x, and on the second - y.
//Output
//    Print inside circle if the point is inside the circle and outside circle if it's outside. Then print a single whitespace followed by inside rectangle 
//if the point is inside the rectangle and outside rectangle otherwise. See the sample tests for a visual description.
//Constraints
//    The coordinates x and y will always be valid floating-point numbers in the range[-1000, 1000].
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;
using System.Threading;
using System.Globalization;

namespace PointCircleRectangle
{
    class PointCircleRectangle
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            double x = double.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double y = double.Parse(line);

            // Checks for given point(x, y) if it is within the circle K({ 1, 1}, 1.5)
            double xCenter = 1;
            double yCenter = 1;
            double radius = 1.5F;

            double distanceCircle = Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y - yCenter, 2));
            bool insideCircle = Math.Abs(distanceCircle) <= radius;

            var pointCircle = "outside circle";
            if (insideCircle)
            {
                pointCircle = "inside circle";
            }

            // checks for given point(x, y) if it is out of the rectangle R(top= 1, left= -1, width= 6, height= 2)
            int xMin = -1;
            int xMax = 5;
            int yMin = -1;
            int yMax = 1;

            bool xInside = (xMin <= x) & (x <= xMax);
            bool yInside = (yMin <= y) & (y <= yMax);

            var pointRectangle = "outside rectangle";
            if (xInside & yInside)
            {
                pointRectangle = "inside rectangle";
            }

            // Print result
            Console.WriteLine("{0} {1}", pointCircle, pointRectangle);
        }
    }
}