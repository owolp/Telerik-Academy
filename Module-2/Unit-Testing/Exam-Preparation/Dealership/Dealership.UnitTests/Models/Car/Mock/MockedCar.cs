namespace Dealership.UnitTests.Models.Car.Mock
{
    public class MockedCar : Dealership.Models.Car
    {
        public MockedCar(string make, string model, decimal price, int seats) 
            : base(make, model, price, seats)
        {
        }

        public string PrintAdditionalInfo()
        {
            return base.PrintAdditionalInfo();
        }
    }
}
