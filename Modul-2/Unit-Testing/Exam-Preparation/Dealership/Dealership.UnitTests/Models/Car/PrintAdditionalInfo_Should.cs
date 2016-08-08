namespace Dealership.UnitTests.Models.Car
{
    using Mock;
    using NUnit.Framework;

    [TestFixture]
    public class PrintAdditionalInfo_Should
    {
        [Test]
        public void ReturnCorrectValidStringWithCarDetails()
        {
            var car = new MockedCar("Skoda", "Fabia", 2000M, 5);

            var actualInfo = car.PrintAdditionalInfo();
            var expectedInfo = "  Seats: 5";

            Assert.AreEqual(expectedInfo, actualInfo);
        }
    }
}