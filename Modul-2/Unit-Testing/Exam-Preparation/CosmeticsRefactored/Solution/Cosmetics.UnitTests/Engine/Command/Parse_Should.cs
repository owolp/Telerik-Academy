namespace Cosmetics.UnitTests.Engine.Command
{
    using System;
    using System.Collections.Generic;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class Parse_Should
    {
        // Parse should return new Command, when the "input" string is in the required valid format.
        [Test]
        public void ReturnNewCommand_WhenTheInputStringIsInTheRequiredValidFormat()
        {
            // Arrange
            string inputToTest = "20CharactersLongText";

            // Act
            var newCommand = Command.Parse(inputToTest);

            // Assert
            Assert.IsInstanceOf<ICommand>(newCommand);
        }

        // Parse should set correct values to the newly returned Command object's Properties "Name", when the "input" string is in the valid required format.
        [Test]
        public void SetCorrectValuesToTheNewlyReturnedCommandObjectsName_WhenTheInputStringIsInTheCorrectFormat()
        {
            // Arrange
            string inputToTest = "commandName firstParam secondParam thirdParam";
            var expectedName = "commandName";

            // Act
            var actual = Command.Parse(inputToTest);

            // Arrange
            Assert.AreEqual(expectedName, actual.Name);
        }

        // Parse should set correct values to the newly returned Command object's Properties "Parameters", when the "input" string is in the valid required format.
        [Test]
        public void SetCorrectValuesToTheNewlyReturnedCommandObjectsParameters_WhenTheInputStringIsInTheCorrectFormat()
        {
            // Arrange
            string inputToTest = "commandName firstParam secondParam thirdParam";
            var expectedParameters = new List<string>() { "firstParam", "secondParam", "thirdParam" };

            // Act
            var actual = Command.Parse(inputToTest);

            // Arrange
            Assert.AreEqual(expectedParameters, actual.Parameters);
        }

        // Parse should throw ArgumentNullException with a message that contains the string "Name", when the "input" string that represents the Command Name is Null Or Empty.
        [Test]
        public void ThrowArgumentNullExceptionWithAMessageThatContainsTheStringName_WhenTheInputStringThatRepresentsTheCommandNameIsNullOrEmpty()
        {
            // Arrange
            string inputToTest = " firstParam secondParam thirdParam";
            var expectedMessage = "Name cannot be null or empty.";

            // Act
            var actual = Assert.Throws<ArgumentNullException>(() => Command.Parse(inputToTest));

            // Assert
            StringAssert.Contains(expectedMessage, actual.Message);
        }

        // Parse should throw ArgumentNullException with a message that contains the string "List", when the "input" string that represents the Command Parameters is Null or Empty.
        [Test]
        public void ThrowArgumentNullExceptionWithAMessageThatContainsTheStringList_WhenTheInputStringThatRepresentsTheCommandParamsIsNullOrEmpty()
        {
            // Arrange
            string inputToTest = "commandName ";
            var expectedMessage = "List of strings cannot be null or empty.";

            // Act
            var actual = Assert.Throws<ArgumentNullException>(() => Command.Parse(inputToTest));

            // Assert
            StringAssert.Contains(expectedMessage, actual.Message);
        }
    }
}