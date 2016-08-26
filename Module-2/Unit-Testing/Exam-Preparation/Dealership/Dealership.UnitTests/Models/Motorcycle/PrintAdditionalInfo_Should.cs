namespace Dealership.UnitTests.Models.Motorcycle
{
    using Mock;
    using NUnit.Framework;

    [TestFixture]
    public class PrintAdditionalInfo_Should
    {
        [Test]
        public void ReturnCorrectValidStringWithMotorcycleDetails()
        {
            var car = new MockedMotorcycle("Suzuki", "GSXR1000", 8000, "Racing");

            var actualInfo = car.PrintAdditionalInfo();
            var expectedInfo = "  Category: Racing";

            Assert.AreEqual(expectedInfo, actualInfo);
        }
    }
}