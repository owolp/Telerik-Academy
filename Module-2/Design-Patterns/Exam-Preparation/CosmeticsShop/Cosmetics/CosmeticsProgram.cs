namespace Cosmetics
{
    using Cosmetics.Engine;
    using Ninject;
    using System.Reflection;
    using Contracts;
    using System;

    public class CosmeticsProgram
    {
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
