using System;

namespace TriangleSurface
{
    class TriangleSurface
    {
        static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());

            double result = (side * altitude) / 2;

            Console.WriteLine("{0:F2}", result);
        }
    }
}