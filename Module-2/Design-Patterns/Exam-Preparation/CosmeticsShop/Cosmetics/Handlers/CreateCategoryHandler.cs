namespace Cosmetics.Handlers
{
    using System;
    using Base;
    using Cosmetics.Contracts;

    public class CreateCategoryHandler : BaseHandler
    {
        private const string CommandName = "CreateCategory";
        private const string CategoryExists = "Category with name {0} already exists!";
        private const string CategoryCreated = "Category with name {0} was created!";

        private ICosmeticsFactory factory;

        public CreateCategoryHandler(ICosmeticsFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory Is Null");
            }

            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var categoryName = command.Parameters[0];

            if (engine.Categories.ContainsKey(categoryName))
            {
                return string.Format(CategoryExists, categoryName);
            }

            var category = this.factory.CreateCategory(categoryName);
            engine.Categories.Add(categoryName, category);

            return string.Format(CategoryCreated, categoryName);
        }
    }
}