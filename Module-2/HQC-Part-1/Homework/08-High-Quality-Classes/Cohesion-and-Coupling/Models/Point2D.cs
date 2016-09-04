namespace CohesionAndCoupling.Models
{
    using System;
    using Contracts;

    public class Point2D : Point1D, IPoint2D
    {
        public Point2D(double x1, double x2, double y1, double y2)
            : base(x1, x2)
        {
            this.Y1 = y1;
            this.Y2 = y2;
        }

        public double Y1 { get; set; }

        public double Y2 { get; set; }

        public override double CalculateDistance()
        {
            double distance = Math.Sqrt(
                ((this.X2 - this.X1) * (this.X2 - this.X1)) +
                ((this.Y2 - this.Y1) * (this.Y2 - this.Y1)));

            return distance;
        }
    }
}
