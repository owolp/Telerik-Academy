namespace Cosmetics.UnitTests.Common.Validator
{
    using System;
    using Cosmetics.Common;
    using NUnit.Framework;

    [TestFixture]
    public class CheckIfNull_Should
    {
        // CheckIfNull should throw NullReferenceException, when the parameter "obj" is null.
        [Test]
        public void ThrowNullReferenceException_WhenObjIsNull()
        {
            // Arrange
            object objectToTest = null;

            // Act && Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(objectToTest));
        }

        // CheckIfNull should NOT throw any Exceptions, when the parameter "obj" is NOT null.
        [Test]
        public void NotThrowNullReferenceException_WhenObjIsNotNull()
        {
            // Arrange
            object objectToTest = new object();

            // Act && Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(objectToTest));
        }
    }
}