namespace Cosmetics.UnitTests.Products.Category.Mock
{
    using System.Collections.Generic;
    using Cosmetics.Contracts;

    internal class MockedCategory : Cosmetics.Products.Category
    {
        public MockedCategory(string name)
            : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
