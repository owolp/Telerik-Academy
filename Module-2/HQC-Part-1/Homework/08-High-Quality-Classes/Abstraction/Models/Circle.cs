namespace Abstraction.Models
{
    using System;
    using Common;
    using Contracts;

    public class Circle : Figure, ICircle
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                Validator.ValidateSideIsNotNegative(
                    value,
                    string.Format(Constants.NumberMustBePositive, "Radius"));

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
