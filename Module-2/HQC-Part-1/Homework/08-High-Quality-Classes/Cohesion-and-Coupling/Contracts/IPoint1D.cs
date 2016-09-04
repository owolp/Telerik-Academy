namespace CohesionAndCoupling.Contracts
{
    public interface IPoint1D
    {
        double X1 { get; set; }

        double X2 { get; set; }

        double CalculateDistance();

        string ToString();
    }
}
