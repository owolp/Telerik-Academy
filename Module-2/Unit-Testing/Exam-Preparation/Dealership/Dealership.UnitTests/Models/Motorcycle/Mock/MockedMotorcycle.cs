namespace Dealership.UnitTests.Models.Motorcycle.Mock
{
    public class MockedMotorcycle : Dealership.Models.Motorcycle
    {
        public MockedMotorcycle(string make, string model, decimal price, string category)
            : base(make, model, price, category)
        {
        }

        public string PrintAdditionalInfo()
        {
            return base.PrintAdditionalInfo();
        }
    }
}
