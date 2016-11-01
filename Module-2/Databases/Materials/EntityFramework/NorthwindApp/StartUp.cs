namespace NorthwindApp
{
    using System;
    using NorthwindData;
    using NorthwindTasks;

    internal class StartUp
    {
        public static void Main()
        {
            /* 01. Using the Visual Studio Entity Framework designer create a
            * DbContext for the Northwind database */

            Console.WriteLine("Task 01");
            var context = new NorthwindEntities();
            Console.WriteLine("Done");

            /* 02. Create a DAO class with static methods which provide functionality
            *for inserting, modifying and deleting customers. */

            Console.WriteLine("Task 02");
            var newCustomer = new Customer()
            {
                CustomerID = "CN",
                CompanyName = "companyName",
            };
            Tasks.AddCustomer(newCustomer);
            Console.WriteLine("Customer added");

            var editCustomer = Tasks.FindById("CN");
            editCustomer.CompanyName += "Updated";
            Tasks.ModifyCustomer(editCustomer);
            Console.WriteLine("Customer modified");

            var deleteCustomer = Tasks.FindById("CN");
            Tasks.DeleteCustomer(deleteCustomer);
            Console.WriteLine("Customer deleted");
            Console.WriteLine(new string('=', 40));

            /* 03. Write a method that finds all customers who have orders made in 1997
             * and shipped to Canada.*/

            var orderYear = 1997;
            var shipCountry = "Canada";
            var orders = Tasks.FindOrdersByYearAndCountry(orderYear, shipCountry);

            Console.WriteLine("Task 03");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Customer.CompanyName} - {order.OrderDate.Value.Year}");
            }

            Console.WriteLine(new string('=', 40));

            /* 04. Implement previous by using native SQL query and executing it through
             * the DbContext. */

            Console.WriteLine("Task 04");
            var ordersSql = Tasks.FindOrdersByYearAndCountrySql(orderYear, shipCountry);

            foreach (var order in ordersSql)
            {
                Console.WriteLine($"{order.Customer.CompanyName} - {order.OrderDate.Value.Year}");
            }

            Console.WriteLine(new string('=', 40));

            /* 05. Write a method that finds all the sales by specified region and period
             * (start / end dates).*/
            Console.WriteLine("Task 05");
            string region = "RJ";
            DateTime fromDate = new DateTime(1995, 1, 1);
            DateTime tillDate = new DateTime(2000, 1, 1);

            var ordersRegion = Tasks.FindOrdersByRegionAndPeriod(region, fromDate, tillDate);

            foreach (var order in ordersRegion)
            {
                Console.WriteLine($"{order.ShipRegion} - {order.Customer.CompanyName} - {order.OrderDate.Value.Year}");
            }

            Console.WriteLine(new string('=', 40));

            /* 06. Create a database called NorthwindTwin with the same structure as Northwind using the
             * features from DbContext. .*/
            Console.WriteLine("Task 06 - this will take a while... Please stand by");
            var name = "NorthwindTwin";
            Tasks.CreateNorthwindTwin(name);
            Console.WriteLine("DB Created - this task was !****!!!***!!**!, but it's done :) a little workaround which is not for production at all");
            Console.WriteLine(new string('=', 40));

            /* 07. Try to open two different data contexts and perform concurrent changes on the same records.*/
            Console.WriteLine("Task 07");
            var changes = Tasks.TwoConnectionToDb();
            Console.WriteLine(changes.ToString().Trim());
            Console.WriteLine(new string('=', 40));

            /* 08. By inheriting the Employee entity class create a class which allows employees to access their
             * corresponding territories as property of type EntitySet<T>.*/
            Console.WriteLine("Task 08");
            var employee = context.Employees.Find(1);
            var territories = employee.CorrespondingTerritories;
            foreach (var territory in territories)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }

            Console.WriteLine(new string('=', 40));
        }
    }
}