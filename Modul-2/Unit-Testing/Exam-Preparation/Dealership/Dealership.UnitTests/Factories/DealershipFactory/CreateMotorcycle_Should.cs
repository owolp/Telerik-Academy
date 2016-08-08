namespace Dealership.UnitTests.Factories.DealershipFactory
{
    using System;
    using Dealership.Factories;
    using Dealership.Models;
    using NUnit.Framework;

    [TestFixture]
    public class CreateMotorcycle_Should
    {
        [Test]
        public void ReturnNewMotorcycle_WhenAllParametersAreValid()
        {
            var dealershipFactory = new DealershipFactory();
            var motorcycle = dealershipFactory.CreateMotorcycle("Suzuki", "GSXR1000", 8000, "Racing");

            Assert.IsInstanceOf<Motorcycle>(motorcycle);
        }

        [Test]
        public void ThrowArgumentNullException_WhenCategoryIsNull()
        {
            var dealershipFactory = new DealershipFactory();

            Assert.Throws<ArgumentNullException>(() => dealershipFactory.CreateMotorcycle("Suzuki", "GSXR1000", 8000, null));
        }

        [Test]
        public void DoesNotThrowException_WhenCategoryIsNotNull()
        {
            var dealershipFactory = new DealershipFactory();

            Assert.DoesNotThrow(() => dealershipFactory.CreateMotorcycle("Suzuki", "GSXR1000", 8000, "Racing"));
        }

        [Test]
        public void ReturnCorrectCategory_WhenCategoryIsValid()
        {
            var dealershipFactory = new DealershipFactory();

            Motorcycle motorcycle = (Motorcycle)dealershipFactory.CreateMotorcycle("Suzuki", "GSXR1000", 8000, "Racing");

            var expectedCategory = "Racing";
            var actualCategory = motorcycle.Category;

            Assert.AreEqual(expectedCategory, actualCategory);
        }

        [TestCase("a")]
        [TestCase("20CharactersLongText")]
        public void ThrowArgumentException_WhenTheCategoryLengthIsNotValid(string category)
        {
            var dealershipFactory = new DealershipFactory();

            Assert.Throws<ArgumentException>(() => dealershipFactory.CreateMotorcycle("Suzuki", "GSXR1000", 8000, category));
        }

        [TestCase("Racing")]
        [TestCase("Naked")]
        public void DoesNotThrowException_WhenTheCategoryLengthIsValid(string category)
        {
            var dealershipFactory = new DealershipFactory();

            Assert.DoesNotThrow(() => dealershipFactory.CreateMotorcycle("Suzuki", "GSXR1000", 8000, category));
        }
    }
}