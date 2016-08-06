namespace Cosmetics.UnitTests.Engine.CosmeticsEngine.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Cosmetics.Engine;

    internal class MockedCosmeticsEngine : CosmeticsEngine
    {
        public MockedCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser)
            : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
