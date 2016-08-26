namespace Cosmetics.UnitTests.Products.ShoppingCart.Mock
{
    using System.Collections.Generic;
    using Contracts;

    internal class MockedShoppingCart : Cosmetics.Products.ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
