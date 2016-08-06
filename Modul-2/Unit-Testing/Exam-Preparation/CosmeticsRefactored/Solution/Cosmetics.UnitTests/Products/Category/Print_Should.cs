namespace Cosmetics.UnitTests.Products.Category
{
    using Cosmetics.Products;
    using NUnit.Framework;

    [TestFixture]
    public class Print_Should
    {
        // Category.Print() should return a string with the category details in the required format.
        [Test]
        public void ReturnValidStringWithCategoryDetails()
        {
            var category = new Category("validName");

            var expected = "validName category - 0 products in total";

            var actual = category.Print();

            Assert.AreEqual(expected, actual);
        }
    }
}