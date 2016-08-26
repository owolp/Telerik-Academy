namespace Dealership.UnitTests.Common.Validator
{
    using System;
    using Dealership.Common;
    using NUnit.Framework;

    [TestFixture]
    public class ValidateIntRange_Should
    {
        [TestCase(10, 1, 5, "message")]
        [TestCase(10, 20, 25, "message")]
        public void ThrowAgrumentException_WhenTheInputValueIsNotInTheMinMaxRange(int value, int min, int max, string message)
        {
            Assert.Throws<ArgumentException>(() => Validator.ValidateIntRange(value, min, max, message));
        }

        [TestCase(4, 1, 5, "message")]
        [TestCase(24, 20, 25, "message")]
        public void ValidateCorrectly_WhenTheInputValueIsInTheMinMaxRange(int value, int min, int max, string message)
        {
           Assert.DoesNotThrow(() => Validator.ValidateIntRange(value, min, max, message));
        }
    }
}