namespace TaskShapes.AbstractModels
{
    using Interfaces;

    public abstract class Shape : ICalculateSurface
    {
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        // abstract method over virtual, because you can't ask for the surface for any Shape
        public abstract double CalculateSurface();
    }
}