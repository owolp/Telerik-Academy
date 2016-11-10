namespace Cosmetics.Handlers.Base
{
    using System;
    using Common;
    using Contracts;
    using Cosmetics.Contracts;

    public abstract class BaseHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command name: {0}!";
        private const string InvalidGenderType = "Invalid gender type!";
        private const string InvalidUsageType = "Invalid usage type!";

        private ICommandHandler nextHandler { get; set; }

        public string HandleRequest(ICommand command, IEngine engine)
        {
            string result = string.Empty;

            if (this.CanHandle(command))
            {
                result = this.Handle(command, engine);
            }
            else if (this.nextHandler != null)
            {
                result = this.nextHandler.HandleRequest(command, engine);
            }
            else
            {
                result = string.Format(InvalidCommand, command.Name);
            }

            return result;
        }

        public void SetSuccessor(ICommandHandler successor)
        {
            this.nextHandler = successor;
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command, IEngine engine);

        protected GenderType GetGender(string genderAsString)
        {
            switch (genderAsString)
            {
                case "men":
                    return GenderType.Men;

                case "women":
                    return GenderType.Women;

                case "unisex":
                    return GenderType.Unisex;

                default:
                    throw new InvalidOperationException(InvalidGenderType);
            }
        }

        protected UsageType GetUsage(string usageAsString)
        {
            switch (usageAsString)
            {
                case "everyday":
                    return UsageType.EveryDay;

                case "medical":
                    return UsageType.Medical;

                default:
                    throw new InvalidOperationException(InvalidUsageType);
            }
        }
    }
}