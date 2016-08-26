namespace IntergalacticTravel.Tests.TeleportStatonTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using Telerik.JustMock;
    using IntergalacticTravel.Contracts;
    using System.Collections.Generic;
    using IntergalacticTravel.Tests.TeleportStatonTests.Mocks;

    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void SetUpAllFieldsCorrectly_WhenNewPassedValidParameters()
        {
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            //Act
            var station = new MockedTeleportationStation(mockedOwner, map, mockedLocation);
            //Assert
            Assert.AreSame(station.GetMap, map);
            Assert.AreSame(station.GetOwner, mockedOwner);
            Assert.AreSame(station.GetLocation, mockedLocation);
        }
    }
}
