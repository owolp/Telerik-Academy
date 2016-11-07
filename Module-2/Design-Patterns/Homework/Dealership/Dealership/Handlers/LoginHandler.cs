namespace Dealership.Handlers
{
    using System.Linq;
    using Engine;

    public class LoginHandler : BaseHandler
    {
        private const string LoginUserCommand = "Login";
        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == LoginUserCommand;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            if (engine.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, engine.LoggedUser.Username);
            }

            var userFound = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (userFound != null && userFound.Password == password)
            {
                engine.LoggedUser = userFound;
                return string.Format(UserLoggedIn, username);
            }

            return WrongUsernameOrPassword;
        }
    }
}
