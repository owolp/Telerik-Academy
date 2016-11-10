namespace Cosmetics.Handlers
{
    using Base;
    using Cosmetics.Contracts;

    public class RemoveFromShoppingCartHandler : BaseHandler
    {
        private const string CommandName = "RemoveFromShoppingCart";
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductDoesNotExistInShoppingCart = "Shopping cart does not contain product with name {0}!";
        private const string ProductRemovedFromShoppingCart = "Product {0} was removed from the shopping cart!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var productToRemoveFromCart = command.Parameters[0];

            if (!engine.Products.ContainsKey(productToRemoveFromCart))
            {
                return string.Format(ProductDoesNotExist, productToRemoveFromCart);
            }

            var product = engine.Products[productToRemoveFromCart];

            if (!engine.ShoppingCart.ContainsProduct(product))
            {
                return string.Format(ProductDoesNotExistInShoppingCart, productToRemoveFromCart);
            }

            engine.ShoppingCart.RemoveProduct(product);

            return string.Format(ProductRemovedFromShoppingCart, productToRemoveFromCart);
        }
    }
}