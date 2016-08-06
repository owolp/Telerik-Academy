namespace Cosmetics.UnitTests.Products.ShoppingCart
{
    using Cosmetics.Contracts;
    using Mock;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class RemoveProduct_Should
    {
        // RemoveProduct should remove the passed product from the products list.
        [Test]
        public void RemoveThePassedProductFromTheProductList()
        {
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct = new Mock<IProduct>();

            mockedShoppingCart.Products.Add(mockedProduct.Object);

            mockedShoppingCart.RemoveProduct(mockedProduct.Object);

            Assert.IsFalse(mockedShoppingCart.Products.Contains(mockedProduct.Object));
        }
    }
}