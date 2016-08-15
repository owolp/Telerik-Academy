namespace IntergalacticTravel.Tests.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using Telerik.JustMock;
    using IntergalacticTravel.Contracts;

    [TestClass]
    public class PayShould
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedObjectIsNull()
        {
            //Arrange
            var unit = new Unit(1, "Pesho");
            //Act
            //Assert
            ThrowsAssert.Throws<NullReferenceException>(() => unit.Pay(null), ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ReturnResourcesObjectWithAmmountsFromCost()
        {
            //Arrange
            var unit = new Unit(1, "Pesho");
            var mockedResources = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResources.GoldCoins).Returns(1);
            Mock.Arrange(() => mockedResources.SilverCoins).Returns(2);
            Mock.Arrange(() => mockedResources.BronzeCoins).Returns(3);
            //Act
            var returnedResources = unit.Pay(mockedResources);
            //Assert
            Assert.AreEqual(mockedResources.GoldCoins, returnedResources.GoldCoins);
            Assert.AreEqual(mockedResources.SilverCoins, returnedResources.SilverCoins);
            Assert.AreEqual(mockedResources.BronzeCoins, returnedResources.BronzeCoins);
        }

        [TestMethod]
        public void DecreaseOwnersResourcesWithAmmountsFromCost()
        {
            //Arrange
            var unit = new Unit(1, "Pesho");
            var mockedResources = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResources.GoldCoins).Returns(1);
            Mock.Arrange(() => mockedResources.SilverCoins).Returns(2);
            Mock.Arrange(() => mockedResources.BronzeCoins).Returns(3);
            var expectedGold = unit.Resources.GoldCoins - mockedResources.GoldCoins;
            var expectedSilver = unit.Resources.SilverCoins - mockedResources.SilverCoins;
            var expectedBronze = unit.Resources.BronzeCoins - mockedResources.BronzeCoins;
            //Act
            var returnedResources = unit.Pay(mockedResources);
            //Assert
            Assert.AreEqual(expectedGold, unit.Resources.GoldCoins);
            Assert.AreEqual(expectedSilver, unit.Resources.SilverCoins);
            Assert.AreEqual(expectedBronze, unit.Resources.BronzeCoins);
        }
    }
}
