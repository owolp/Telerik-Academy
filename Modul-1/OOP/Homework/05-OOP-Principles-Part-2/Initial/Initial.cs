namespace Initial
{
    using System;
    using System.Globalization;
    using System.Threading;
    using TaskBankAccounts.Models.Account;
    using TaskBankAccounts.Models.Bank;
    using TaskBankAccounts.Models.Customer;
    using TaskRangeExceptions;
    using TaskShapes.AbstractModels;
    using TaskShapes.Models;

    public class Initial
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Problem 1:");
            Console.WriteLine();
            TestShapes();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Problem 2:");
            Console.WriteLine();
            TestBank();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Problem 3:");
            Console.WriteLine();
            TestExceptions();
        }

        public static void TestShapes()
        {
            Shape triangle = new Triangle(1, 2);
            Shape rectangle = new Rectangle(5, 6);
            Shape square = new Square(3);

            Shape[] shapes = new Shape[] { triangle, rectangle, square };

            foreach (var shape in shapes)
            {
                Console.WriteLine("The surface of the {0} is {1}cm.", shape.GetType().Name, shape.CalculateSurface());
            }
        }

        public static void TestBank()
        {
            Bank bank = new Bank();
           
            bank.AddAccount(new Deposit(new Company(1, "First Company"), 7500.0m, 1));
            bank.AddAccount(new Loan(new Company(2, "Second Company"), 8500.0m, 24));
            bank.AddAccount(new Mortgage(new Company(3, "Third Company"), 9500.0m, 32));
            bank.AddAccount(new Deposit(new Individual(4, "Ivan Ivanov"), 7500.0m, 1));
            bank.AddAccount(new Loan(new Individual(5, "Petar Petrov"), 7500.0m, 24));
            bank.AddAccount(new Mortgage(new Individual(6, "Svilen Svilenov"), 7500.0m, 32));

            Console.WriteLine("List of the added accounts sorted by balance:");
            Console.WriteLine(bank);
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("The monthly interest rates are:");

            var random = new Random();

            foreach (var account in bank)
            {
                var months = random.Next(0, 8);
                var rate = account.CalculateMonthlyInteresetRate(months);
                Console.WriteLine("The rate of customer {0} for {1} months is {2}.", account.Customer.ToString().Substring(6), months, rate);
            }
        }

        public static void TestExceptions()
        {
            try
            {
                throw new InvalidRangeException<int>(2, 50);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            try
            {
                throw new InvalidRangeException<DateTime>(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}