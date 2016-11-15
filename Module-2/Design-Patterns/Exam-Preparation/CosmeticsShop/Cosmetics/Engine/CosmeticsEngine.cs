namespace Cosmetics.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common.Contracts;
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Handlers.Contracts;

    public sealed class CosmeticsEngine : IEngine
    {
        private const string InvalidCommand = "Invalid command name: {0}!";
        private const string CategoryExists = "Category with name {0} already exists!";
        private const string CategoryCreated = "Category with name {0} was created!";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductAddedToCategory = "Product {0} added to category {1}!";
        private const string ProductRemovedCategory = "Product {0} removed from category {1}!";
        private const string ShampooAlreadyExist = "Shampoo with name {0} already exists!";
        private const string ShampooCreated = "Shampoo with name {0} was created!";
        private const string ToothpasteAlreadyExist = "Toothpaste with name {0} already exists!";
        private const string ToothpasteCreated = "Toothpaste with name {0} was created!";
        private const string ProductAddedToShoppingCart = "Product {0} was added to the shopping cart!";
        private const string ProductDoesNotExistInShoppingCart = "Shopping cart does not contain product with name {0}!";
        private const string ProductRemovedFromShoppingCart = "Product {0} was removed from the shopping cart!";
        private const string TotalPriceInShoppingCart = "${0} total price currently in the shopping cart!";
        private const string InvalidGenderType = "Invalid gender type!";
        private const string InvalidUsageType = "Invalid usage type!";

        private readonly ICosmeticsFactory factory;
        private readonly IIOProvider uiProvider;
        private readonly ICommandHandler commandHandler;

        private readonly IShoppingCart shoppingCart;
        private readonly IDictionary<string, ICategory> categories;
        private readonly IDictionary<string, IProduct> products;

        public CosmeticsEngine(
            ICosmeticsFactory factory,
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

            this.shoppingCart = new ShoppingCart();
            this.categories = new Dictionary<string, ICategory>();
            this.products = new Dictionary<string, IProduct>();
        }

        public IDictionary<string, ICategory> Categories
        {
            get { return this.categories; }
        }

        public IDictionary<string, IProduct> Products
        {
            get { return this.products; }
        }

        public IShoppingCart ShoppingCart
        {
            get { return this.shoppingCart; }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Parse(currentLine);
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

        private string ProcessSingleCommand(ICommand command)
        {
            return commandHandler.HandleRequest(command, this);
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            Console.Write(output.ToString());
        }
    }
}
