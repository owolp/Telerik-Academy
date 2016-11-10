namespace Dealership.Handlers
{
    using System.Text;
    using Base;
    using Common.Enums;
    using Engine;

    public class ShowUsersHandler : BaseHandler
    {
        private const string ShowUsersCommand = "ShowUsers";
        private const string YouAreNotAnAdmin = "You are not an admin!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == ShowUsersCommand;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            if (engine.LoggedUser.Role != Role.Admin)
            {
                return YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in engine.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
