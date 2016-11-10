namespace Dealership.Handlers
{
    using System;
    using System.Linq;
    using Base;
    using Common.Enums;
    using Engine;
    using Factories;

    public class RegisterUserHandler : BaseHandler
    {
        private const string RegisterUserCommand = "RegisterUser";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserRegisterеd = "User {0} registered successfully!";

        private IDealershipFactory factory;

        public RegisterUserHandler(IDealershipFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory Is Null");
            }

            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == RegisterUserCommand;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];

            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            if (engine.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, engine.LoggedUser.Username);
            }

            if (engine.Users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                return string.Format(UserAlreadyExist, username);
            }

            var user = this.factory.CreateUser(username, firstName, lastName, password, role.ToString());
            engine.LoggedUser = user;
            engine.Users.Add(user);

            return string.Format(UserRegisterеd, username);
        }
    }
}
