namespace CohesionAndCoupling.Contracts
{
    public interface IBox : IFigure
    {
        double Width { get; set; }

        double Height { get; set; }

        double Depth { get; set; }

        double CalculateDiagonalXY();

        double CalculateDiagonalXZ();

        double CalculateDiagonalYZ();

        double CalculateDiagonalXYZ();
    }
}
