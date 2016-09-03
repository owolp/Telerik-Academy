namespace Methods.Models
{
    using System;
    using Common;
    using Contracts;

    public class Triangle : ITriangle
    {
        private double sideA;

        private double sideB;

        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public double SideA
        {
            get
            {
                return this.sideA;
            }

            private set
            {
                Validator.ValidateSideIsNotNegative(value, string.Format(Constants.NumberMustBePositive, "Side A"));

                this.sideA = value;
            }
        }

        public double SideB
        {
            get
            {
                return this.sideB;
            }

            private set
            {
                Validator.ValidateSideIsNotNegative(value, string.Format(Constants.NumberMustBePositive, "Side B"));

                this.sideB = value;
            }
        }

        public double SideC
        {
            get
            {
                return this.sideC;
            }

            private set
            {
                Validator.ValidateSideIsNotNegative(value, string.Format(Constants.NumberMustBePositive, "Side C"));

                this.sideC = value;
            }
        }

        public double CalculateArea()
        {
            double semiPerimether = this.CalculateSemiPerimether();
            double area = Math.Sqrt(semiPerimether * (semiPerimether - this.SideA) * (semiPerimether - this.SideB) * (semiPerimether - this.SideC));

            return area;
        }

        public double CalculateSemiPerimether()
        {
            double semiPerimether = (this.sideA + this.sideB + this.sideC) / 2;

            return semiPerimether;
        }
    }
}
