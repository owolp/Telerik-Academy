namespace Cosmetics.Handlers
{
    using Base;
    using Cosmetics.Contracts;

    public class RemoveFromCategoryHandler : BaseHandler
    {
        private const string CommandName = "RemoveFromCategory";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductRemovedCategory = "Product {0} removed from category {1}!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var categoryNameToRemove = command.Parameters[0];
            var productToRemove = command.Parameters[1];

            if (!engine.Categories.ContainsKey(categoryNameToRemove))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToRemove);
            }

            if (!engine.Products.ContainsKey(productToRemove))
            {
                return string.Format(ProductDoesNotExist, productToRemove);
            }

            var category = engine.Categories[categoryNameToRemove];
            var product = engine.Products[productToRemove];

            category.RemoveCosmetics(product);

            return string.Format(ProductRemovedCategory, productToRemove, categoryNameToRemove);
        }
    }
}