using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dealership.Handlers.Contracts;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        // Commands constants

        // TODO: Remove commands
        private const string InvalidCommand = "Invalid command!";

        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserRegisterеd = "User {0} registered successfully!";
        private const string UserNotLogged = "You are not logged! Please login first!";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string UserLoggedOut = "You logged out!";
        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";
        private const string YouAreNotAnAdmin = "You are not an admin!";

        private const string CommentAddedSuccessfully = "{0} added comment successfully!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";

        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";

        private const string CommentDoesNotExist = "The comment does not exist!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";

        private static readonly IEngine SingleInstance = new DealershipEngine();

        private IDealershipFactory factory;
        private ICollection<IUser> users;
        private IUser loggedUser;

        private readonly ICommandHandler commandHandler;

        private DealershipEngine()
        {
            this.factory = new DealershipFactory();
            this.users = new List<IUser>();
            this.loggedUser = null;
        }

        public static IEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this.factory = new DealershipFactory();
            this.users = new List<IUser>();
            this.loggedUser = null;
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
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

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = new Command(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
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

            Console.Write(output.ToString());
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
