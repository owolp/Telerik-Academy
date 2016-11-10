namespace Dealership.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Base;
    using Engine;
    using Factories;

    public class AddCommentHandler : BaseHandler
    {
        private const string AddCommentCommand = "AddComment";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        private IDealershipFactory factory;

        public AddCommentHandler(IDealershipFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory Is Null");
            }

            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == AddCommentCommand;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            var comment = this.factory.CreateComment(content);
            comment.Author = engine.LoggedUser.Username;
            var user = engine.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(AddCommentHandler.NoSuchUser, author);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, AddCommentHandler.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            engine.LoggedUser.AddComment(comment, vehicle);

            return string.Format(AddCommentHandler.CommentAddedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
