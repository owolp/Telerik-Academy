namespace Cosmetics.Handlers
{
    using System;
    using System.Linq;
    using Base;
    using Cosmetics.Contracts;

    public class CreateToothpasteHandler : BaseHandler
    {
        private const string CommandName = "CreateToothpaste";
        private const string ToothpasteAlreadyExist = "Toothpaste with name {0} already exists!";
        private const string ToothpasteCreated = "Toothpaste with name {0} was created!";

        private ICosmeticsFactory factory;

        public CreateToothpasteHandler(ICosmeticsFactory factory)
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
            var toothpasteName = command.Parameters[0];
            var toothpasteBrand = command.Parameters[1];
            var toothpastePrice = decimal.Parse(command.Parameters[2]);
            var toothpasteGender = base.GetGender(command.Parameters[3]);
            var toothpasteIngredients = command.Parameters[4].Trim().Split(',').ToList();

            if (engine.Products.ContainsKey(toothpasteName))
            {
                return string.Format(ToothpasteAlreadyExist, toothpasteName);
            }

            var toothpaste = this.factory.CreateToothpaste(toothpasteName, toothpasteBrand, toothpastePrice, toothpasteGender, toothpasteIngredients);
            engine.Products.Add(toothpasteName, toothpaste);

            return string.Format(ToothpasteCreated, toothpasteName);
        }
    }
}