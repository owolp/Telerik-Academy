namespace Dealership.UnitTests.Common.Validator
{
    using System;
    using Dealership.Common;
    using NUnit.Framework;

    [TestFixture]
    public class ValidateNull_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheInputValueObjectIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Validator.ValidateNull(null, "string"));
        }

        [Test]
        public void DoesNotThrowException_WhenTheInputValueObjectIsNotNull()
        {
            var objectToTest = new object();

            Assert.DoesNotThrow(() => Validator.ValidateNull(objectToTest, "string"));
        }
    }
}