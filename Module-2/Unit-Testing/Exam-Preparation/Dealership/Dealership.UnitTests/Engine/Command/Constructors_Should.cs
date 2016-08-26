namespace Dealership.UnitTests.Engine.Command
{
    using System;
    using System.Collections.Generic;
    using Dealership.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class Constructors_Should
    {
        [TestCase("ShowUsers")]
        [TestCase("Logout")]
        public void ReturnValidName_WhenTheInputStringIsInTheCorrectFormat(string inputToTest)
        {
            var command = new Command(inputToTest);

            var expectedName = inputToTest;
            var actualName = command.Name;

            Assert.AreSame(expectedName, actualName);
        }

        [Test]
        public void AddTheParametersCorrectly_WhenTheInputStringIsInTheCorrectFormat()
        {
            var inputToTest = "AddComment {{E toa go znam, brato. Padal e mai :)}} pesho 1";
            var command = new Command(inputToTest);

            var expectedParams = new List<string>()
            {
                "E toa go znam, brato. Padal e mai :)",
                "pesho",
                "1"
            };

            var actualParams = command.Parameters;

            Assert.AreEqual(expectedParams, actualParams);
        }
    }
}