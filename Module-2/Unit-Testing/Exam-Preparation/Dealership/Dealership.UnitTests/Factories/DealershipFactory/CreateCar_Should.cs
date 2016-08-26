namespace Dealership.UnitTests.Factories.DealershipFactory
{
    using System;
    using Dealership.Factories;
    using Dealership.Models;
    using NUnit.Framework;

    [TestFixture]
    public class CreateCar_Should
    {
        [Test]
        public void ReturnNewCar_WhenAllParametersAreValid()
        {
            var dealershipFactory = new DealershipFactory();
            var car = dealershipFactory.CreateCar("Skoda", "Fabia", 2000M, 5);

            Assert.IsInstanceOf<Car>(car);
        }

        [TestCase(0)]
        [TestCase(20)]
        public void ThrowArgumentException_WhenSeatsCountIsNotValid(int seats)
        {
            var dealershipFactory = new DealershipFactory();

            Assert.Throws<ArgumentException>(() => dealershipFactory.CreateCar("Skoda", "Fabia", 2000M, seats));
        }

        [Test]
        public void DoesNotThrowException_WhenSeatsCountIsValid()
        {
            var dealershipFactory = new DealershipFactory();

            Assert.DoesNotThrow(() => dealershipFactory.CreateCar("Skoda", "Fabia", 2000M, 5));
        }

        [Test]
        public void ReturnCorrectSeatsCount_WhenSeatsCountIsValid()
        {
            var dealershipFactory = new DealershipFactory();

            Car car = (Car)dealershipFactory.CreateCar("Skoda", "Fabia", 2000M, 5);

            var expectedSeats = 5;
            var actualSeats = car.Seats;

            Assert.AreEqual(expectedSeats, actualSeats);
        }
    }
}