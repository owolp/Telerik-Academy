namespace Space3D
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Test
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Problem 2. Static read-only field
            Point3D zeroPoint = Point3D.O;

            Console.WriteLine("Zero Point Property:");
            Console.WriteLine("\t {0}", zeroPoint);

            // Problem 3. Static class
            Point3D firstPoint = new Point3D(1.2, 6.3, 8.9);
            Point3D secondPoint = new Point3D(6.1, 3.6, 9.8);

            double distance = Distance.CalculateDistance(firstPoint, secondPoint);

            Console.WriteLine("The distance between {0} and {1} is {2:F6}", firstPoint.ToString(), secondPoint.ToString(), distance);

            // Problem 4. Path
            Path path = new Path();

            path.AddPoint(firstPoint);
            path.AddPoint(secondPoint);

            PathStorage.Save(path); // The file is saved to ../../../PathStorage/path

            path.ClearPath();

            PathStorage.Load(path); // The file is loaded from ../../../PathStorage/path
        }
    }
}
