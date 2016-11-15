namespace Cosmetics.Handlers
{
    using Base;
    using Cosmetics.Contracts;

    public class AddToShoppingCartHandler : BaseHandler
    {
        private const string CommandName = "AddToShoppingCart";
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductAddedToShoppingCart = "Product {0} was added to the shopping cart!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var productName = command.Parameters[0];

            if (!engine.Products.ContainsKey(productName))
            {
                return string.Format(ProductDoesNotExist, productName);
            }

            var product = engine.Products[productName];
            engine.ShoppingCart.AddProduct(product);

            return string.Format(ProductAddedToShoppingCart, productName);
        }
    }
}