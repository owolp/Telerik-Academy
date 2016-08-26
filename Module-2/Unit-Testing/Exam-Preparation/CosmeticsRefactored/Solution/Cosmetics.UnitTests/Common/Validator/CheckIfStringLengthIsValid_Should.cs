namespace Cosmetics.UnitTests.Common.Validator
{
    using System;
    using Cosmetics.Common;
    using NUnit.Framework;

    [TestFixture]
    public class CheckIfStringLengthIsValid_Should
    {
        // CheckIfStringLengthIsValid should throw IndexOutOfRangeException, when the length of the parameter "text" is lower than the minimum allowed value or greater than the maximum allowed value.
        [TestCase(10, 15)]
        [TestCase(25, 30)]
        public void ThrowIndexOutOfRangeException_WhenTheLengthOfTheParamTextIsLowerThanTheMinAllowedAndGreaterThanTheMaxAllowed(int minLength, int maxLength)
        {
            // Arrange
            string textToTest = "20CharactersLongText";

            // Act && Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(textToTest, maxLength, minLength));
        }

        // CheckIfStringLengthIsValid should NOT throw any Exceptions, when the length of the parameter "text" is in the allowed boundaries.
        [TestCase(10, 25)]
        [TestCase(1, 30)]
        public void NotThrowIndexOutOfRangeException_WhenTheLengthOfTheParamTextIsInTheAllowedBoundaries(int minLength, int maxLength)
        {
            // Arrange
            string textToTest = "20CharactersLongText";

            // Act && Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(textToTest, maxLength, minLength));
        }
    }
}