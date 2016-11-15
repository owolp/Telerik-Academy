namespace Cosmetics.Handlers
{
    using Base;
    using Cosmetics.Contracts;

    public class ShowCategoryHandler : BaseHandler
    {
        private const string CommandName = "ShowCategory";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var categoryToShow = command.Parameters[0];

            if (!engine.Categories.ContainsKey(categoryToShow))
            {
                return string.Format(CategoryDoesNotExist, categoryToShow);
            }

            var category = engine.Categories[categoryToShow];

            return category.Print();
        }
    }
}