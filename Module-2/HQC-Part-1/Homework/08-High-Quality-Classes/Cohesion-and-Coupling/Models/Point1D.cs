namespace CohesionAndCoupling.Models
{
    using System;
    using Common;
    using Contracts;

    public class Point1D : IPoint1D
    {
        public Point1D(double x1, double x2)
        {
            this.X1 = x1;
            this.X2 = x2;
        }

        public double X1 { get; set; }

        public double X2 { get; set; }

        public virtual double CalculateDistance()
        {
            double distance = Math.Sqrt(
                (this.X2 - this.X1) * (this.X2 - this.X1));

            return distance;
        }

        public new virtual string ToString()
        {
            var currentDimentionName = this.GetType().Name;
            var currentDimention = currentDimentionName.Substring(currentDimentionName.Length - 2);
            var calculatedDistance = this.CalculateDistance();
            string toString = string.Format(Constants.PointToString, currentDimention, calculatedDistance);

            return toString;
        }
    }
}
