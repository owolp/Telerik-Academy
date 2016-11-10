namespace Dealership.Handlers
{
    using Base;
    using Engine;

    public class LogoutHandler : BaseHandler
    {
        private const string LogoutUserCommand = "Logout";
        private const string UserLoggedOut = "You logged out!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == LogoutUserCommand;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            engine.LoggedUser = null;

            return UserLoggedOut;
        }
    }
}
