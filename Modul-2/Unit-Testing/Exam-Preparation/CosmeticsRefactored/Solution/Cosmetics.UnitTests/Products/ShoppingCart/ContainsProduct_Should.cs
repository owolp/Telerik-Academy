namespace Cosmetics.UnitTests.Products.ShoppingCart
{
    using Contracts;
    using Mock;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ContainsProduct_Should
    {
        // ContainsProduct should return true if the passed product is contained within the products list.
        [Test]
        public void ReturnTrue_WhenThePassedProductIsContainedWithinTheProductsList()
        {
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct = new Mock<IProduct>();

            mockedShoppingCart.Products.Add(mockedProduct.Object);

            Assert.IsTrue(mockedShoppingCart.ContainsProduct(mockedProduct.Object));
        }

        [Test]
        public void ReturnFalse_WhenThePassedProductIsNotContainedWithinTheProductsList()
        {
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct = new Mock<IProduct>();

            Assert.IsFalse(mockedShoppingCart.ContainsProduct(mockedProduct.Object));
        }
    }
}