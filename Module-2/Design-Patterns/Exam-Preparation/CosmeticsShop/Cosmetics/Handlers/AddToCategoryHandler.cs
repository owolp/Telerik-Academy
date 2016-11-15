namespace Cosmetics.Handlers
{
    using Base;
    using Cosmetics.Contracts;

    public class AddToCategoryHandler : BaseHandler
    {
        private const string CommandName = "AddToCategory";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductAddedToCategory = "Product {0} added to category {1}!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var categoryNameToAdd = command.Parameters[0];
            var productToAdd = command.Parameters[1];

            if (!engine.Categories.ContainsKey(categoryNameToAdd))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToAdd);
            }

            if (!engine.Products.ContainsKey(productToAdd))
            {
                return string.Format(ProductDoesNotExist, productToAdd);
            }

            var category = engine.Categories[categoryNameToAdd];
            var product = engine.Products[productToAdd];

            category.AddCosmetics(product);

            return string.Format(ProductAddedToCategory, productToAdd, categoryNameToAdd);
        }
    }
}