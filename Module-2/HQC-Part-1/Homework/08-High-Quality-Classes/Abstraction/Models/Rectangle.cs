namespace Abstraction.Models
{
    using Common;
    using Contracts;

    public class Rectangle : Figure, IRectangle
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                Validator.ValidateSideIsNotNegative(
                    value,
                    string.Format(Constants.NumberMustBePositive, "Width"));

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                Validator.ValidateSideIsNotNegative(
                    value,
                    string.Format(Constants.NumberMustBePositive, "Height"));

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}
