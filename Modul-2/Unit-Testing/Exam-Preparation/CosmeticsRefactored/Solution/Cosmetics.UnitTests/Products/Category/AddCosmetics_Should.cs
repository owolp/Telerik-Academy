namespace Cosmetics.UnitTests.Products.Category
{
    using Contracts;
    using Mock;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AddCosmetics_Should
    {
        // AddCosmetics should add the passed cosmetic to the products list.
        [Test]
        public void AddThePassedProductToTheProductList()
        {
            var mockedCategory = new MockedCategory("validName");
            var mockedProduct = new Mock<IProduct>();

            mockedCategory.AddProduct(mockedProduct.Object);

            Assert.IsTrue(mockedCategory.Products.Contains(mockedProduct.Object));
        }

        // RemoveCosmetics should remove the passed cosmetic from the products list.
        [Test]
        public void RemoveThePassedProductToTheProductList()
        {
            var mockedCategory = new MockedCategory("validName");
            var mockedProduct = new Mock<IProduct>();

            mockedCategory.Products.Add(mockedProduct.Object);

            mockedCategory.RemoveProduct(mockedProduct.Object);

            Assert.IsFalse(mockedCategory.Products.Contains(mockedProduct.Object));
        }
    }
}