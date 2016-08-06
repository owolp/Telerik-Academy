namespace Cosmetics.UnitTests.Products.ShoppingCart
{
    using Contracts;
    using Mock;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class TotalPrice_Should
    {
        // TotalPrice should return the total sum of the prices of all products in the products list.
        // (or 0 if there are no products)
        [Test]
        public void ReturnTheTotalSumOfTheProductsInTheProductsList()
        {
            var mockedShoppingCart = new MockedShoppingCart();
            var product = new Mock<IProduct>();

            product.SetupGet(p => p.Price).Returns(10.0M);

            mockedShoppingCart.Products.Add(product.Object);

            Assert.AreEqual(10.0M, mockedShoppingCart.TotalPrice());
        }

        [Test]
        public void ReturnTheZeroSumOf_WhenThereareNoProductsInTheProductsList()
        {
            var mockedShoppingCart = new MockedShoppingCart();

            Assert.AreEqual(0M, mockedShoppingCart.TotalPrice());
        }
    }
}