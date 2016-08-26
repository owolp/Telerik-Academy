namespace IntergalacticTravel.Tests.BusinessOwnerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using Telerik.JustMock;
    using IntergalacticTravel.Contracts;
    using System.Collections.Generic;

    [TestClass]
    public class CollectProfitsShould
    {
        [TestMethod]
        public void IncreaseOwnerResourcesByTotalResourcesGeneratedFromHisTeleportStations()
        {
            //Arrange
            var mockedResources = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResources.GoldCoins).Returns(1);
            Mock.Arrange(() => mockedResources.SilverCoins).Returns(2);
            Mock.Arrange(() => mockedResources.BronzeCoins).Returns(3);

            var mockedStation = Mock.Create<ITeleportStation>();
            Mock.Arrange(() => mockedStation.PayProfits(Arg.IsAny<IBusinessOwner>())).Returns(mockedResources);
            var stations = new List<ITeleportStation>();
            stations.Add(mockedStation);
            var owner = new BusinessOwner(666, "GoshoNinjata", stations);
            //Act
            owner.CollectProfits();
            //Assert
            Assert.AreEqual(owner.Resources.GoldCoins, mockedResources.GoldCoins);
            Assert.AreEqual(owner.Resources.SilverCoins, mockedResources.SilverCoins);
            Assert.AreEqual(owner.Resources.BronzeCoins, mockedResources.BronzeCoins);
        }
    }
}
