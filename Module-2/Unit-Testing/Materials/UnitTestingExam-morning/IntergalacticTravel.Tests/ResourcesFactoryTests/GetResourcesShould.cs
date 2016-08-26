namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using Telerik.JustMock;

    [TestClass]
    public class GetResourcesShould
    {
        [TestMethod]
        public void ThrowOverflowException_WhenArgumentIsValidCommandFormatWithTooHihValues()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            //Act
            //Assert
            ThrowsAssert.Throws<OverflowException>
                (() => resFactory.GetResources("create resources silver(10) gold(97853252356623523532) bronze(20)"), ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowOverflowException_WhenArgumentIsValidCommandFormatWithTooHihValuesCase2()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            //Act
            //Assert
            ThrowsAssert.Throws<OverflowException>
                (() => resFactory.GetResources("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)"), ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowOverflowException_WhenArgumentIsValidCommandFormatWithTooHihValuesCase3()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            //Act
            //Assert
            ThrowsAssert.Throws<OverflowException>
                (() => resFactory.GetResources("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444) "), ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowInvalidOperationException_WhenArgumentIsInvalidCommandFormat()
        {
            //throw InvalidOperationException, which contains the string "command", when the input string represents an invalid command.

            //Arrange
            var resFactory = new ResourcesFactory();
            //Act
            //Assert
            ThrowsAssert.Throws<InvalidOperationException>
                (() => resFactory.GetResources("show me the money"), "command", ExceptionMessageCompareOptions.Contains, ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ReturnNewResources_WhenArgumentIsValid()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            //Act
            var resource = resFactory.GetResources("create resources gold(20) silver(30) bronze(40)");
            //Assert
            Assert.AreEqual(resource.GetType(), typeof(Resources));
        }

        [TestMethod]
        public void ReturnNewResourcesWithCorrectProperties_WhenArgumentIsValidCommandInOrderGoldSilverBronze()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            uint expectedGold = 20;
            uint expectedSilver = 30;
            uint expectedBronze = 40;
            //Act
            var resource = resFactory.GetResources("create resources gold(20) silver(30) bronze(40)");
            //Assert
            Assert.AreEqual(expectedGold, resource.GoldCoins);
            Assert.AreEqual(resource.SilverCoins, expectedSilver);
            Assert.AreEqual(resource.BronzeCoins, expectedBronze);
        }

        [TestMethod]
        public void ReturnNewResourcesWithCorrectProperties_WhenArgumentIsValidCommandInOrderGoldBronzeSilver()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            uint expectedGold = 20;
            uint expectedSilver = 30;
            uint expectedBronze = 40;
            //Act
            var resource = resFactory.GetResources("create resources gold(20) bronze(40) silver(30)");
            //Assert
            Assert.AreEqual(expectedGold, resource.GoldCoins);
            Assert.AreEqual(resource.SilverCoins, expectedSilver);
            Assert.AreEqual(resource.BronzeCoins, expectedBronze);
        }

        [TestMethod]
        public void ReturnNewResourcesWithCorrectProperties_WhenArgumentIsValidCommandInOrderBronzeSilverGold()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            uint expectedGold = 20;
            uint expectedSilver = 30;
            uint expectedBronze = 40;
            //Act
            var resource = resFactory.GetResources("create resources bronze(40) silver(30) gold(20)");
            //Assert
            Assert.AreEqual(expectedGold, resource.GoldCoins);
            Assert.AreEqual(resource.SilverCoins, expectedSilver);
            Assert.AreEqual(resource.BronzeCoins, expectedBronze);
        }

        [TestMethod]
        public void ReturnNewResourcesWithCorrectProperties_WhenArgumentIsValidCommandInOrderBronzeGoldSilver()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            uint expectedGold = 20;
            uint expectedSilver = 30;
            uint expectedBronze = 40;
            //Act
            var resource = resFactory.GetResources("create resources bronze(40) gold(20) silver(30)");
            //Assert
            Assert.AreEqual(expectedGold, resource.GoldCoins);
            Assert.AreEqual(resource.SilverCoins, expectedSilver);
            Assert.AreEqual(resource.BronzeCoins, expectedBronze);
        }

        [TestMethod]
        public void ReturnNewResourcesWithCorrectProperties_WhenArgumentIsValidCommandInOrderSilverBronzeGold()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            uint expectedGold = 20;
            uint expectedSilver = 30;
            uint expectedBronze = 40;
            //Act
            var resource = resFactory.GetResources("create resources silver(30) bronze(40) gold(20)");
            //Assert
            Assert.AreEqual(expectedGold, resource.GoldCoins);
            Assert.AreEqual(resource.SilverCoins, expectedSilver);
            Assert.AreEqual(resource.BronzeCoins, expectedBronze);
        }

        [TestMethod]
        public void ReturnNewResourcesWithCorrectProperties_WhenArgumentIsValidCommandInOrderSilverGoldBronze()
        {
            //Arrange
            var resFactory = new ResourcesFactory();
            uint expectedGold = 20;
            uint expectedSilver = 30;
            uint expectedBronze = 40;
            //Act
            var resource = resFactory.GetResources("create resources silver(30) gold(20) bronze(40)");
            //Assert
            Assert.AreEqual(expectedGold, resource.GoldCoins);
            Assert.AreEqual(resource.SilverCoins, expectedSilver);
            Assert.AreEqual(resource.BronzeCoins, expectedBronze);
        }
    }
}
