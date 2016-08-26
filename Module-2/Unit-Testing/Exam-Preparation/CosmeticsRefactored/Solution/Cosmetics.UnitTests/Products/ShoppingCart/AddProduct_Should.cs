namespace Cosmetics.UnitTests.Products.ShoppingCart
{
    using Contracts;
    using Mock;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AddProduct_Should
    {
        // AddProduct should add the passed product to the products list.
        [Test]
        public void AddThePassedProductToTheProductsList()
        {
            var mockedShoppingCart = new MockedShoppingCart();
            var mockedProduct = new Mock<IProduct>();

            mockedShoppingCart.AddProduct(mockedProduct.Object);

            Assert.IsTrue(mockedShoppingCart.Products.Contains(mockedProduct.Object));
            ///// Assert.AreSame(mockedShoppingCart.Products[0], mockedProduct.Object);
        }
    }
}