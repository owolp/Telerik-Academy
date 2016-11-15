namespace Cosmetics.NinjectBindings
{
    using System;
    using Common;
    using Common.Contracts;
    using Contracts;
    using Engine;
    using Handlers;
    using Handlers.Contracts;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    public class CosmeticsBindings : NinjectModule
    {
        private const string AddToCategoryHandlerName = "AddToCategoryHandler";
        private const string AddToShoppingCartHandlerName = "AddToShoppingCartHandler";
        private const string CreateCategoryHandlerName = "CreateCategoryHandler";
        private const string CreateShampooHandlerName = "CreateShampooHandler";
        private const string CreateToothpasteHandlerName = "CreateToothpasteHandler";
        private const string RemoveFromCategoryHandlerName = "RemoveFromCategoryHandler";
        private const string RemoveFromShoppingCartHandlerName = "RemoveFromShoppingCartHandler";
        private const string ShowCategoryHandlerName = "ShowCategoryHandler";
        private const string TotalPriceHandlerName = "TotalPriceHandler";

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

            this.Bind<ICosmeticsFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandHandler>().To<AddToCategoryHandler>().Named(AddToCategoryHandlerName);
            this.Bind<ICommandHandler>().To<AddToShoppingCartHandler>().Named(AddToShoppingCartHandlerName);
            this.Bind<ICommandHandler>().To<CreateCategoryHandler>().Named(CreateCategoryHandlerName);
            this.Bind<ICommandHandler>().To<CreateShampooHandler>().Named(CreateShampooHandlerName);
            this.Bind<ICommandHandler>().To<CreateToothpasteHandler>().Named(CreateToothpasteHandlerName);
            this.Bind<ICommandHandler>().To<RemoveFromCategoryHandler>().Named(RemoveFromCategoryHandlerName);
            this.Bind<ICommandHandler>().To<RemoveFromShoppingCartHandler>().Named(RemoveFromShoppingCartHandlerName);
            this.Bind<ICommandHandler>().To<ShowCategoryHandler>().Named(ShowCategoryHandlerName);
            this.Bind<ICommandHandler>().To<TotalPriceHandler>().Named(TotalPriceHandlerName);

            this.Bind<ICommandHandler>().ToMethod(contex =>
            {
                var addToCategoryHandler = contex.Kernel.Get<ICommandHandler>(AddToCategoryHandlerName);
                var addToShoppingCartHandler = contex.Kernel.Get<ICommandHandler>(AddToShoppingCartHandlerName);
                var createCategoryHandler = contex.Kernel.Get<ICommandHandler>(CreateCategoryHandlerName);
                var createShampooHandler = contex.Kernel.Get<ICommandHandler>(CreateShampooHandlerName);
                var createToothpaseHandler = contex.Kernel.Get<ICommandHandler>(CreateToothpasteHandlerName);
                var removeFromCategoryHandler = contex.Kernel.Get<ICommandHandler>(RemoveFromCategoryHandlerName);
                var removeFromShoppingCartHandler = contex.Kernel.Get<ICommandHandler>(RemoveFromShoppingCartHandlerName);
                var showCategoryHandler = contex.Kernel.Get<ICommandHandler>(ShowCategoryHandlerName);
                var totalPriceHandler = contex.Kernel.Get<ICommandHandler>(TotalPriceHandlerName);

                addToCategoryHandler.SetSuccessor(addToShoppingCartHandler);
                addToShoppingCartHandler.SetSuccessor(createCategoryHandler);
                createCategoryHandler.SetSuccessor(createShampooHandler);
                createShampooHandler.SetSuccessor(createToothpaseHandler);
                createToothpaseHandler.SetSuccessor(removeFromCategoryHandler);
                removeFromCategoryHandler.SetSuccessor(removeFromShoppingCartHandler);
                removeFromShoppingCartHandler.SetSuccessor(showCategoryHandler);
                showCategoryHandler.SetSuccessor(totalPriceHandler);

                return addToCategoryHandler;
            })
            .WhenInjectedInto<CosmeticsEngine>()
            .InSingletonScope();

            this.Bind<IEngine>().To<CosmeticsEngine>().InSingletonScope();
        }
    }
}
