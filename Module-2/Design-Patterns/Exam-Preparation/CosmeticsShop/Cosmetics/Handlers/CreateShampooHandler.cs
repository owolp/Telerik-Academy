namespace Cosmetics.Handlers
{
    using System;
    using Base;
    using Cosmetics.Contracts;

    public class CreateShampooHandler : BaseHandler
    {
        private const string CommandName = "CreateShampoo";
        private const string ShampooAlreadyExist = "Shampoo with name {0} already exists!";
        private const string ShampooCreated = "Shampoo with name {0} was created!";

        private ICosmeticsFactory factory;

        public CreateShampooHandler(ICosmeticsFactory factory)
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
            var shampooName = command.Parameters[0];
            var shampooBrand = command.Parameters[1];
            var shampooPrice = decimal.Parse(command.Parameters[2]);
            var shampooGender = base.GetGender(command.Parameters[3]);
            var shampooMilliliters = uint.Parse(command.Parameters[4]);
            var shampooUsage = base.GetUsage(command.Parameters[5]);

            if (engine.Products.ContainsKey(shampooName))
            {
                return string.Format(ShampooAlreadyExist, shampooName);
            }

            var shampoo = this.factory.CreateShampoo(shampooName, shampooBrand, shampooPrice, shampooGender, shampooMilliliters, shampooUsage);
            engine.Products.Add(shampooName, shampoo);

            return string.Format(ShampooCreated, shampooName);
        }
    }
}