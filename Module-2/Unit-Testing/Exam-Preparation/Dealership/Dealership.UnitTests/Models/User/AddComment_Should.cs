namespace Dealership.UnitTests.Models.User
{
    using Contracts;
    using Dealership.Common.Enums;
    using Dealership.Models;
    using Dealership.UnitTests.Models.Vehicle.Mock;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AddComment_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheCommentToAddIsNull()
        {
            var user = new User("ivancho", "Ivan", "Ivanov", "admin", (Role)Enum.Parse(typeof(Role), "Admin"));

            var mockedIVehicleToAddComment = new Mock<IVehicle>();
            IComment objectToTest = null;

            Assert.Throws<ArgumentNullException>(() => user.AddComment(objectToTest, mockedIVehicleToAddComment.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheVehicleToAddIsNull()
        {
            var user = new User("ivancho", "Ivan", "Ivanov", "admin", (Role)Enum.Parse(typeof(Role), "Admin"));

            var mockedICommentToAddComment = new Mock<IComment>();
            IVehicle objectToTest = null;

            Assert.Throws<ArgumentNullException>(() => user.AddComment(mockedICommentToAddComment.Object, objectToTest));
        }

        [Test]
        public void AddCommentToVehicleToAddComment_WhenTheCommentParameterIsCorrect()
        {
            var user = new User("ivancho", "Ivan", "Ivanov", "admin", (Role)Enum.Parse(typeof(Role), "Admin"));

            var mockedComment = new Mock<IComment>();
            var mockedVehicle = new MockedVehicle("Skoda", "Fabia", 2000M, (VehicleType)Enum.Parse(typeof(VehicleType), "Car"));

            mockedVehicle.Comments.Add(mockedComment.Object);

            Assert.IsTrue(mockedVehicle.Comments.Contains(mockedComment.Object));
        }
    }
}