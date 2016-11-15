namespace Cosmetics.Handlers
{
    using Base;
    using Cosmetics.Contracts;

    public class TotalPriceHandler : BaseHandler
    {
        private const string CommandName = "TotalPrice";
        private const string TotalPriceInShoppingCart = "${0} total price currently in the shopping cart!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            return string.Format(TotalPriceInShoppingCart, engine.ShoppingCart.TotalPrice());
        }
    }
}