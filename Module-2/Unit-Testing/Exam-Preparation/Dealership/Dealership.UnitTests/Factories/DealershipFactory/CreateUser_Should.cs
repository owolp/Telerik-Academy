namespace Dealership.UnitTests.Factories.DealershipFactory
{
    using System;
    using Contracts;
    using Dealership.Common.Enums;
    using Dealership.Factories;
    using Dealership.Models;
    using NUnit.Framework;

    [TestFixture]
    public class CreateUser_Should
    {
        [Test]
        public void ReturnNewUser_WhenAllParametersAreValid()
        {
            var dealershipFactory = new DealershipFactory();
            var user = dealershipFactory.CreateUser("ivancho", "Ivan", "Ivanov", "admin", "Admin");

            Assert.IsInstanceOf<IUser>(user);
        }
    }
}