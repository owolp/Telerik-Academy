using Dealership.Engine;
using System;
using System.IO;
using Dealership.Handlers.Contracts;
using Dealership.Factories;
using Ninject;
using System.Reflection;

namespace Dealership
{
    public class Startup
    {
        //public static void Main()
        //{
        //    // DealershipEngine.Instance.Start();

        //    IDealershipFactory dealershipFactory = new DealershipFactory();
        //    IHandlerFactory handleFactory = new HandlerFactory(dealershipFactory);
        //    IEngine engine = new DealershipEngine(dealershipFactory);
        //    engine.Start();

        //}

        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            SingletonTest(ninject);

            var engine = ninject.Get<IEngine>();
            engine.Start();
        }

        private static void SingletonTest(StandardKernel ninjectKernel)
        {
            var firstInstace = ninjectKernel.Get<IEngine>();
            var secondInstance = ninjectKernel.Get<IEngine>();
            var isSameReference = firstInstace == secondInstance;

            Console.WriteLine($"{nameof(firstInstace)} and {nameof(secondInstance)} reference the same instance: {isSameReference}");
        }
    }
}
