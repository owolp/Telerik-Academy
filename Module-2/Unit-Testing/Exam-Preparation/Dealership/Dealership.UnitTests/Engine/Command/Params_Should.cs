namespace Dealership.UnitTests.Engine.Command
{
    using System;
    using Dealership.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class Params_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheInputNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Command(" p Petar Petrov 123456"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithName_WhenTheInputNameIsEmpty()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new Command(" p Petar Petrov 123456"));

            StringAssert.Contains("Name cannot be null or empty.", exception.Message);
        }
    }
}