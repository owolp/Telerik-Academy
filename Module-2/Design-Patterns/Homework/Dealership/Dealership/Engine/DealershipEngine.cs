using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dealership.Handlers.Contracts;
using Dealership.Common.Contracts;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private const string UserNotLogged = "You are not logged! Please login first!";

        private readonly IDealershipFactory factory;
        private readonly IIOProvider uiProvider;
        private readonly ICommandHandler commandHandler;

        private ICollection<IUser> users;
        private IUser loggedUser;

        
        public DealershipEngine(
            IDealershipFactory factory,
            IIOProvider uiProvider,
            ICommandHandler commandHandler)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (uiProvider == null)
            {
                throw new ArgumentNullException(nameof(uiProvider));
            }

            if (commandHandler == null)
            {
                throw new ArgumentNullException(nameof(commandHandler));
            }

            this.factory = factory;
            this.uiProvider = uiProvider;
            this.commandHandler = commandHandler;

            this.users = new List<IUser>();
            this.loggedUser = null;
        }

        public IUser LoggedUser
        {
            get { return this.loggedUser; }
            set { this.loggedUser = value; }
        }

        public ICollection<IUser> Users
        {
            get { return this.users; }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this.users = new List<IUser>();
            this.loggedUser = null;
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.uiProvider.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.factory.CreateCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.uiProvider.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.uiProvider.Write(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login")
            {
                if (this.loggedUser == null)
                {
                    return UserNotLogged;
                }
            }

            return commandHandler.HandleRequest(command, this);
        }
    }
}
