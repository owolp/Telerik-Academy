namespace IntergalacticTravel.Tests.TeleportStatonTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;
    using Telerik.JustMock;
    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Exceptions;
    using IntergalacticTravel.Tests.TeleportStatonTests.Mocks;

    [TestClass]
    public class TeleportUnitShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionContaining_unitToTeleport_WhenUnitArgumentIsNull()
        { 
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            var mockedLocation = Mock.Create<ILocation>();

            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            //Asert
            ThrowsAssert.Throws<ArgumentNullException>(() => station.TeleportUnit(null, mockedLocation), "unitToTeleport", ExceptionMessageCompareOptions.Contains, ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowArgumentNullExceptionContaining_destination_WhenLocationArgumentIsNull()
        {
            //with a message that contains the string "destination", when ILocation destination is null.
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedPath = Mock.Create<IPath>();
            var mockedUnit = Mock.Create<IUnit>();
            map.Add(mockedPath);
            var mockedLocation = Mock.Create<ILocation>();

            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            //Asert
            ThrowsAssert.Throws<ArgumentNullException>(() => station.TeleportUnit(mockedUnit, null), "destination", ExceptionMessageCompareOptions.Contains, ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowTeleportOutOfRangeExceptionContaining_unitToTeleport_dot_CurrentLocation_WhenUnitIsTooFarAway()
        {
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            var mockedLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnit.CurrentLocation).Returns(mockedLocation);

            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);

            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            //Asert
            ThrowsAssert.Throws<TeleportOutOfRangeException>(() => station.TeleportUnit(mockedUnit, mockedLocation), "unitToTeleport.CurrentLocation", ExceptionMessageCompareOptions.Contains, ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowInvalidTeleportationLocationException_units_will_overlap_WhenTryingToTeleportOverAnotherUnit()
        {
            //InvalidTeleportationLocationException, with a message that contains the string "units will overlap" when trying to teleport a unit to a location which another unit has already taken. 
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedPath = Mock.Create<IPath>();
            var mockedUnit = Mock.Create<IUnit>();
            var mockedCollidingUnit  = Mock.Create<IUnit>();
            map.Add(mockedPath);
            var mockedLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedLocation.Planet.Name).Returns("Namek");
            Mock.Arrange(() => mockedLocation.Coordinates.Latitude).Returns(211);
            Mock.Arrange(() => mockedLocation.Coordinates.Longtitude).Returns(211);
            Mock.Arrange(() => mockedCollidingUnit.CurrentLocation).Returns(mockedLocation);
            var unitsAtLocation = new List<IUnit>();
            unitsAtLocation.Add(mockedCollidingUnit);
            Mock.Arrange(() => mockedLocation.Planet.Units).Returns(unitsAtLocation);
            Mock.Arrange(() => mockedUnit.CurrentLocation);
            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);
            var mockedStationLocation = Mock.Create<ILocation>();


            var station = new TeleportStation(mockedOwner, map, mockedStationLocation);
            //Act
            //Asert
            ThrowsAssert.Throws<InvalidTeleportationLocationException>(() => station.TeleportUnit(mockedUnit, mockedLocation), "units will overlap", ExceptionMessageCompareOptions.Contains, ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowInsufficientResourcesExceptionContaining_FREE_LUNCH_WhenTryingToTeleportButNotEnoughMinerals()
        {
            //should throw InsufficientResourcesException, with a message that contains the string "FREE LUNCH", when trying to teleport a unit to a given Location, but the service costs more than the unit's current available resources.
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            var mockedResources = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResources.GoldCoins).Returns(0);
            Mock.Arrange(() => mockedResources.SilverCoins).Returns(0);
            Mock.Arrange(() => mockedResources.BronzeCoins).Returns(0);
            Mock.Arrange(() => mockedUnit.Resources).Returns(mockedResources);

            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            //Asert
            ThrowsAssert.Throws<InsufficientResourcesException>(() => station.TeleportUnit(mockedUnit, mockedLocation), "FREE LUNCH", ExceptionMessageCompareOptions.Contains, ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void ThrowLocationNotFoundExceptionContaining_Planet_WhenTryingToTeleportToAPlanetNotOnTheListOfTheStation()
        {
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("Namk");
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);
            var mockedDestination = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedDestination.Planet.Name).Returns("Fake Namek");

            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            //Asert
            ThrowsAssert.Throws<LocationNotFoundException>(() => station.TeleportUnit(mockedUnit, mockedDestination), ExceptionInheritanceOptions.Inherits);
        }

        [TestMethod]
        public void RequiePayment_WhenValidatedSuccessfullyAndUnitIsReady()
        {
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);


            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            station.TeleportUnit(mockedUnit, mockedLocation);
            //Asert
            Mock.Assert(() => mockedUnit.Pay(Arg.IsAny<IResources>()), Occurs.Once());
        }

        [TestMethod]
        public void ObtainPaymentAndAddToItsResources_WhenValidatedSuccessfullyAndUnitIsReady()
        {
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            var mockedResources = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResources.GoldCoins).Returns(1);
            Mock.Arrange(() => mockedResources.SilverCoins).Returns(2);
            Mock.Arrange(() => mockedResources.BronzeCoins).Returns(3);
            Mock.Arrange(() => mockedUnit.Pay(Arg.IsAny<IResources>())).Returns(mockedResources);
            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);


            var station = new MockedTeleportationStation(mockedOwner, map, mockedLocation);
            //Act
            station.TeleportUnit(mockedUnit, mockedLocation);
            //Asert
            Assert.AreEqual(mockedResources.BronzeCoins, station.Resources.BronzeCoins);
            Assert.AreEqual(mockedResources.SilverCoins, station.Resources.SilverCoins);
            Assert.AreEqual(mockedResources.GoldCoins, station.Resources.GoldCoins);
        }

        [TestMethod]
        public void SetUnitPreviousLocationToCurrentLocation_WhenValidatedSuccessfullyAndUnitIsTeleported()
        {
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);

            var expectedLocation = mockedUnit.CurrentLocation;
            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            station.TeleportUnit(mockedUnit, mockedLocation);
            //Asert
            Assert.AreEqual(mockedUnit.PreviousLocation, expectedLocation);
        }

        [TestMethod]
        public void SetUnitCurrentLocationToTargetLocation_WhenValidatedSuccessfullyAndUnitIsTeleported()
        {
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);

            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            station.TeleportUnit(mockedUnit, mockedLocation);
            //Asert
            Assert.AreEqual(mockedUnit.CurrentLocation, mockedLocation);
        }

        [TestMethod]
        public void AddUnitToListOfUnitsOfTargetLocation_WhenValidatedSuccessfullyAndUnitIsTeleported()
        {
            //should Add the unitToTeleport to the list of Units of the targetLocation (Planet.Units), when all of the validations pass successfully and the unit is on its way to being teleported.
            //Arrange
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var map = new List<IPath>();
            var mockedLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("Namek");
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("Glx");
            map.Add(mockedPath);
            var mockedUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnit.CanPay(Arg.IsAny<IResources>())).Returns(true);
            var mockedDestination = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedDestination.Planet.Name).Returns("Namek");
            Mock.Arrange(() => mockedDestination.Planet.Galaxy.Name).Returns("Glx");

            var station = new TeleportStation(mockedOwner, map, mockedLocation);
            //Act
            station.TeleportUnit(mockedUnit, mockedLocation);
            //Asert
            Assert.IsTrue(mockedPath.TargetLocation.Planet.Units.Contains(mockedUnit));
        }


    }
}
