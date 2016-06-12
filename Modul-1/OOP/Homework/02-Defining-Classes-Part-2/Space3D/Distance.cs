namespace Space3D
{
    using System;

    public static class Distance
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            // Math.Pow is slower, so I'm not using it.
            return Math.Sqrt(
                ((firstPoint.CoordinateX - secondPoint.CoordinateX) * (firstPoint.CoordinateX - secondPoint.CoordinateX)) +
                ((firstPoint.CoordinateY - secondPoint.CoordinateY) * (firstPoint.CoordinateY - secondPoint.CoordinateY)) +
                ((firstPoint.CoordinateZ - secondPoint.CoordinateZ) * (firstPoint.CoordinateZ - secondPoint.CoordinateZ)));
        }
    }
}
