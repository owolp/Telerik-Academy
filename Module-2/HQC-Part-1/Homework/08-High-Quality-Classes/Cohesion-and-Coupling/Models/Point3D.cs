namespace CohesionAndCoupling.Models
{
    using System;
    using Contracts;

    public class Point3D : Point2D, IPoint3D
    {
        public Point3D(double x1, double x2, double y1, double y2, double z1, double z2) 
            : base(x1, x2, y1, y2)
        {
            this.Z1 = z1;
            this.Z2 = z2;
        }

        public double Z1 { get; set; }

        public double Z2 { get; set; }

        public override double CalculateDistance()
        {
            double distance = Math.Sqrt(
                ((this.X2 - this.X1) * (this.X2 - this.X1)) +
                ((this.Y2 - this.Y1) * (this.Y2 - this.Y1)) +
                ((this.Z2 - this.Z1) * (this.Z2 - this.Z1)));

            return distance;
        }
    }
}
