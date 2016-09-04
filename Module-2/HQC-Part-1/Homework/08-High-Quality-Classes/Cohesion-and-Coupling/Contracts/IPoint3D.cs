namespace CohesionAndCoupling.Contracts
{
    public interface IPoint3D : IPoint2D
    {
        double Z1 { get; set; }

        double Z2 { get; set; }
    }
}
