namespace Abstraction.Models
{
    using Common;
    using Contracts;

    public abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            var type = this.GetType().Name;
            var perimeter = this.CalculatePerimeter();
            var surface = this.CalculateSurface();

            string toString = string.Format(Constants.FigureToString, type, perimeter, surface);

            return toString;
        }
    }
}
