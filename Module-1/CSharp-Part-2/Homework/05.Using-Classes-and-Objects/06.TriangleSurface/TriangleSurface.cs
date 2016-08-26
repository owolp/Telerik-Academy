using System;

namespace TriangleSurface
{
    class TriangleSurface
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());

            double result = (a * b * Math.Sin(Math.PI / 180 * angle)) / 2;

            Console.WriteLine("{0:F2}", result);
        }
    }
}