namespace Cosmetics.UnitTests.Common.Validator
{
    using System;
    using Cosmetics.Common;
    using NUnit.Framework;

    [TestFixture]
    public class CheckIfStringIsNullOrEmpty_Should
    {
        // CheckIfStringIsNullOrEmpty should throw NullReferenceException, when the parameter "text" is null or empty.
        [TestCase("")]
        [TestCase(null)]
        public void ThrowNullReferenceException_WhenParamTextIsNullOrEmpty(string text)
        {
            // Act && Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        // CheckIfStringIsNullOrEmpty should NOT throw any Exceptions, when the parameter "text" is NOT null or empty.
        public void NotThrowNullReferenceException_WhenParamTextIsNotNullOrEmpty()
        {
            // Arrange
            string textToTest = "NotNullOrEmptyText";

            // Act && Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(textToTest));
        }
    }
}