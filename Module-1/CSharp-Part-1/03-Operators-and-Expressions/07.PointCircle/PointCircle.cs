//07. Point in a circle
//Description
//Write a program that reads the coordinates of a point x and y and using an expression checks if given point(x, y) is inside a circle K({ 0, 0}, 2) - 
//the center has coordinates(0, 0) and the circle has radius 2. The program should then print "yes DISTANCE" if the point is inside the circle or "no DISTANCE" 
//if the point is outside the circle.
//In place of DISTANCE print the distance from the beginning of the coordinate system - (0, 0) - to the given point.
//Input
//You will receive exactly two lines, the first containing the x coordinate, the second containing the y coordinate.
//Output
//Output a single line in the format described above. The distance should be always printed with 2-digit precision after the floating point.
//Constraints
//The numbers x and y will always be valid floating point numbers in the range (-1000, 1000)
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;
using System.Threading;
using System.Globalization;

namespace PointCircle
{
    class PointCircle
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            float x = float.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            float y = float.Parse(line);

            int xCenter = 0;
            int yCenter = 0;
            int radius = 2;

            double distance = Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y - yCenter, 2));

            string answer;
            if (Math.Abs(distance) <= radius)
            {
                answer = "yes";
            }
            else
            {
                answer = "no";
            }
            Console.WriteLine("{0} {1:F2}", answer, distance);
        }
    }
}