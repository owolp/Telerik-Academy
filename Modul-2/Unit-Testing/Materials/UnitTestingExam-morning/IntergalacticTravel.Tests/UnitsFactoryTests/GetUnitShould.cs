namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using Telerik.JustMock;
    using IntergalacticTravel.Exceptions;

    [TestClass]
    public class GetUnitShould
    {
        [TestMethod]
        public void ReturnNewProcyonUnit_WhenValidCorrespondingCommandIsPassed()
        {
            //Arrange
            var factory = new UnitsFactory();
            //Act
            var unit = factory.GetUnit("create unit Procyon Gosho 1");
            //Assert
            Assert.AreEqual(unit.GetType(), typeof(Procyon));
        }

        [TestMethod]
        public void ReturnNewLuytenUnit_WhenValidCorrespondingCommandIsPassed()
        {
            //Arrange
            var factory = new UnitsFactory();
            //Act
            var unit = factory.GetUnit("create unit Luyten Pesho 2");
            //Assert
            Assert.AreEqual(unit.GetType(), typeof(Luyten));
        }

        [TestMethod]
        public void ReturnNewLacailleUnit_WhenValidCorrespondingCommandIsPassed()
        {
            //Arrange
            var factory = new UnitsFactory();
            //Act
            var unit = factory.GetUnit("create unit Lacaille Tosho 3");
            //Assert
            Assert.AreEqual(unit.GetType(), typeof(Lacaille));
        }

        [TestMethod]
        public void  ThrowInvalidUnitCreationCommandException_WhenInvalidCommandIsPassedWithoutSpaces()
        {
            //Arrange
            var factory = new UnitsFactory();
            //Act
            //Assert
            ThrowsAssert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit("createunitLacaille Tosho 3"), ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowInvalidUnitCreationCommandException_WhenInvalidCommandIsPassedWithWrongCommands()
        {
            //Arrange
            var factory = new UnitsFactory();
            //Act
            //Assert
            ThrowsAssert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit("1 Gosho create Procylon unit"), ExceptionInheritanceOptions.Inherits);
        }
    }
}