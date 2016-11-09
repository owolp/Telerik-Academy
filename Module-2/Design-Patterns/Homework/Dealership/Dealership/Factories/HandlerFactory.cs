namespace Dealership.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Handlers;
    using Handlers.Contracts;

    public class HandlerFactory : IHandlerFactory
    {
        public ICommandHandler CreateAndAttachHandlers()
        {
            var addVehicleHandler = new AddVehicleHandler();
            var loginHandler = new LoginHandler();
            var logoutHandler = new LogoutHandler();
            var registerUserHandler = new RegisterUserHandler();
            var removeCommentHandler = new RemoveCommentHandler();
            var removeVehicleHandler = new RemoveVehicleHandler();
            var showUsersHandler = new ShowUsersHandler();
            var showVehiclesHandler = new ShowVehiclesHandler();

            addVehicleHandler.SetSuccessor(loginHandler);
            loginHandler.SetSuccessor(logoutHandler);
            logoutHandler.SetSuccessor(registerUserHandler);
            registerUserHandler.SetSuccessor(removeCommentHandler);
            removeCommentHandler.SetSuccessor(removeVehicleHandler);
            removeVehicleHandler.SetSuccessor(showUsersHandler);
            showUsersHandler.SetSuccessor(showVehiclesHandler);

            return addVehicleHandler;
        }
    }
}
