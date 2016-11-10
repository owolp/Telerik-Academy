namespace Dealership.NinjectBindings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Common.Contracts;
    using Contracts;
    using Engine;
    using Factories;
    using Handlers;
    using Handlers.Contracts;
    using Models;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    public class DealershipBindings : NinjectModule
    {
        private const string RegisterUserCommandHandlerName = "RegisterUserCommandHandler";
        private const string LoginCommandHandlerName = "LoginCommandHandler";
        private const string LogoutCommandHandlerName = "LogoutCommandHandler";
        private const string AddVehicleCommandHandlerName = "AddVehicleCommandHandler";
        private const string RemoveVehicleCommandHandlerName = "RemoveVehicleCommandHandler";
        private const string AddCommentCommandHandlerName = "AddCommentCommandHandler";
        private const string RemoveCommentCommandHandlerName = "RemoveCommentCommandHandler";
        private const string ShowUsersCommandHandlerName = "ShowUsersCommandHandler";
        private const string ShowVehiclesCommandHandlerName = "ShowVehiclesCommandHandler";

        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";

        public override void Load()
        {
            Kernel.Bind(x =>
                x.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<Func<string>>().ToMethod(ctx => () =>
            {
                return Console.ReadLine();
            });

            this.Bind<Action<string>>().ToMethod(ctx => (param) =>
            {
                Console.Write(param);
            });

            this.Bind<IIOProvider>().To<GenericIOProvider>();

            this.Bind<IVehicle>().To<Car>().Named(CarName);
            this.Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);
            this.Bind<IVehicle>().To<Truck>().Named(TruckName);

            this.Bind<IDealershipFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandHandler>().To<AddCommentHandler>().Named(AddCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<AddVehicleHandler>().Named(AddVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<LoginHandler>().Named(LoginCommandHandlerName);
            this.Bind<ICommandHandler>().To<LogoutHandler>().Named(LogoutCommandHandlerName);
            this.Bind<ICommandHandler>().To<RegisterUserHandler>().Named(RegisterUserCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveCommentHandler>().Named(RemoveCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveVehicleHandler>().Named(RemoveVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowUsersHandler>().Named(ShowUsersCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowVehiclesHandler>().Named(ShowVehiclesCommandHandlerName);

            this.Bind<ICommandHandler>().ToMethod(ctx =>
            {
                var addCommnentHandler = ctx.Kernel.Get<ICommandHandler>(AddCommentCommandHandlerName);
                var addVehicleHandler = ctx.Kernel.Get<ICommandHandler>(AddVehicleCommandHandlerName);
                var loginHandler = ctx.Kernel.Get<ICommandHandler>(LoginCommandHandlerName);
                var logoutHandler = ctx.Kernel.Get<ICommandHandler>(LogoutCommandHandlerName);
                var registerUserHandler = ctx.Kernel.Get<ICommandHandler>(RegisterUserCommandHandlerName);
                var removeCommentHandler = ctx.Kernel.Get<ICommandHandler>(RemoveCommentCommandHandlerName);
                var removeVehicleHandler = ctx.Kernel.Get<ICommandHandler>(RemoveVehicleCommandHandlerName);
                var showUsersHandler = ctx.Kernel.Get<ICommandHandler>(ShowUsersCommandHandlerName);
                var showVehiclesHandler = ctx.Kernel.Get<ICommandHandler>(ShowVehiclesCommandHandlerName);

                registerUserHandler.SetSuccessor(loginHandler);
                loginHandler.SetSuccessor(logoutHandler);
                logoutHandler.SetSuccessor(addVehicleHandler);
                addVehicleHandler.SetSuccessor(removeVehicleHandler);
                removeVehicleHandler.SetSuccessor(addCommnentHandler);
                addCommnentHandler.SetSuccessor(removeCommentHandler);
                removeCommentHandler.SetSuccessor(showUsersHandler);
                showUsersHandler.SetSuccessor(showVehiclesHandler);

                return registerUserHandler;
            })
            .WhenInjectedInto<DealershipEngine>()
            .InSingletonScope();

            this.Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
        }
    }
}
