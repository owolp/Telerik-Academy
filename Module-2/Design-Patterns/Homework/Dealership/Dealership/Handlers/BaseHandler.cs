namespace Dealership.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Engine;

    public abstract class BaseHandler : IBaseHandler
    {
        private const string InvalidCommand = "Invalid command!";

        private BaseHandler nextHandler { get; set; }

        public void SetSuccessor(BaseHandler successor)
        {
            this.nextHandler = successor;
        }

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

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command, IEngine engine);
    }
}
