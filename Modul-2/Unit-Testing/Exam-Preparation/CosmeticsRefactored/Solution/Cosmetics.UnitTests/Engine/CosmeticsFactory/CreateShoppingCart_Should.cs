namespace Cosmetics.UnitTests.Engine.CosmeticsFactory
{
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CreateShoppingCart_Should
    {
        // CreateShoppingCart should always return a new ShoppingCart.
        [Test]
        public void ReturnShoppingCart()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            var actual = cosmeticsFactory.CreateShoppingCart();

            Assert.IsInstanceOf<IShoppingCart>(actual);
        }
    }
}