using System.Collections.Generic;

namespace Cosmetics.Contracts
{
    public interface IEngine
    {
        IDictionary<string, ICategory> Categories { get; }

        IDictionary<string, IProduct> Products { get; }

        IShoppingCart ShoppingCart { get; }

        void Start();
    }
}
