namespace Cohesion_and_Coupling_ConsoleClient
{
    using System;
    using CohesionAndCoupling.Models;

    public class StartUp
    {
        public static void Main()
        {
            var fileWithoutExtension = new File("example");
            Console.WriteLine(fileWithoutExtension.GetExtension());
            Console.WriteLine(fileWithoutExtension.GetNameWithoutExtension());

            var fileWithExtension = new File("example.pdf");
            Console.WriteLine(fileWithExtension.GetExtension());
            Console.WriteLine(fileWithExtension.GetNameWithoutExtension());

            var fileWithTwoExtensions = new File("example.new.pdf");
            Console.WriteLine(fileWithTwoExtensions.GetExtension());
            Console.WriteLine(fileWithTwoExtensions.GetNameWithoutExtension());

            var point2D = new Point2D(1, -2, 3, 4);
            Console.WriteLine(point2D.ToString());

            var point3D = new Point3D(5, 2, -1, 3, -6, 4);
            Console.WriteLine(point3D.ToString());

            var box = new Box(3, 4, 5);
            Console.WriteLine(box.ToString());
        }
    }
}
