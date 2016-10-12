using System;

using SchoolSystem.Framework.Engines;
using SchoolSystem.Framework.Engines.Contracts;
using SchoolSystem.Framework.IO;
using SchoolSystem.Framework.IO.Contracts;

namespace SchoolSystem.Framework
{
    public static class Startup
    {
        public static void Main()
        {
            var userInterface = GetUserInterface();
            var commandProvider = GetCommandProvider();
            var engine = GetEngine(userInterface, commandProvider);
            engine.Start();
        }

        private static IUserInterfaceProvider GetUserInterface()
        {
            var ui = new UserInterfaceProvider(Console.ReadLine, Console.WriteLine);
            return ui;
        }

        private static ICommandProvider GetCommandProvider()
        {
            var commandProvider = new CommandProvider();
            return commandProvider;
        }

        private static ISchoolSystemEngine GetEngine(IUserInterfaceProvider userInterface, ICommandProvider commandProvider)
        {
            var engine = new SchoolSystemEngine(userInterface, commandProvider);
            return engine;
        }
    }
}
