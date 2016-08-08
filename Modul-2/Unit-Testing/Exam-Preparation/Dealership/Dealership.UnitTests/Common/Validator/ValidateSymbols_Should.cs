namespace Dealership.UnitTests.Common.Validator
{
    using System;
    using Dealership.Common;
    using NUnit.Framework;

    [TestFixture]
    public class ValidateSymbols_Should
    {
        [Test]
        public void ThrowArgumentException_WhenTheInputValueDoesNotMatchTheInputPattern()
        {
            var valueToTest = "valueToTest";
            var patterToTest = "patterToTest";

            Assert.Throws<ArgumentException>(() => Validator.ValidateSymbols(valueToTest, patterToTest, "message"));
        }

        [Test]
        public void DoesNotThrowException_WhenTheInputValueMatchesTheInputPattern()
        {
            var valueToTest = "valueToTest";
            var patterToTest = "valueToTest";

            Assert.DoesNotThrow(() => Validator.ValidateSymbols(valueToTest, patterToTest, "message"));
        }
    }
}