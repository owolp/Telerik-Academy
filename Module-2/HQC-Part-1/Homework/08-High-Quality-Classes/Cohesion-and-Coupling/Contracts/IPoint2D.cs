namespace CohesionAndCoupling.Contracts
{
    public interface IPoint2D : IPoint1D
    {
        double Y1 { get; set; }

        double Y2 { get; set; }
    }
}
