namespace NorthwindTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NorthwindData;

    public class Tasks
    {
        public static NorthwindEntities GetContext()
        {
            var context = new NorthwindEntities();

            return context;
        }

        public static void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var context = GetContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public static void ModifyCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var context = GetContext();
            var customerToEdit = context.Customers.Find(customer.CustomerID);

            if (customerToEdit == null)
            {
                throw new ArgumentNullException("Customer not found");
            }

            var customerToEditCurrentValues = context.Entry(customerToEdit).CurrentValues;
            customerToEditCurrentValues.SetValues(customer);

            context.SaveChanges();
        }

        public static void DeleteCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var context = GetContext();
            var customerToDelete = context.Customers.Find(customer.CustomerID);

            if (customerToDelete == null)
            {
                throw new ArgumentNullException("Customer not found");
            }

            context.Customers.Remove(customerToDelete);

            context.SaveChanges();
        }

        public static ICollection<Order> FindOrdersByYearAndCountry(int orderYear, string shipCountry)
        {
            ICollection<Order> result = new List<Order>();
            var context = GetContext();

            result = context.Orders
                .Where(o => o.OrderDate.Value.Year == orderYear && o.ShipCountry == shipCountry)
                .ToList();

            return result;
        }

        public static ICollection<Order> FindOrdersByYearAndCountrySql(int orderYear, string shipCountry)
        {
            ICollection<Order> result = new List<Order>();
            var context = GetContext();
            var query = string.Format($@"SELECT *
                                        FROM Orders o
                                        JOIN Customers c
                                            ON o.CustomerID = c.CustomerID
                                        WHERE YEAR(o.OrderDate) = '{orderYear}'
                                        AND o.ShipCountry = '{shipCountry}'");

            result = context.Orders.SqlQuery(query).Distinct().ToList();

            return result;
        }

        public static ICollection<Order> FindOrdersByRegionAndPeriod(string region, DateTime fromDate, DateTime TillDate)
        {
            ICollection<Order> result = new List<Order>();
            var context = GetContext();

            result = context.Orders
                .Where(o => o.ShipRegion == region && o.OrderDate >= fromDate && o.OrderDate <= TillDate)
                .ToList();

            return result;
        }

        public static void CreateNorthwindTwin(string name)
        {
            var context = new NorthwindEntities(name);
            context.Database.CreateIfNotExists();
        }

        public static StringBuilder TwoConnectionToDb()
        {
            StringBuilder result = new StringBuilder();

            var firstContext = GetContext();
            var secondContext = GetContext();

            var personFirstContext = firstContext.Customers.Find("ALFKI");
            result.AppendLine($"First Context Before: {personFirstContext.City}");

            var personSecondContext = secondContext.Customers.Find("ALFKI");
            result.AppendLine($"Second Context Before: {personSecondContext.City}");

            personFirstContext.City = "Sofia";
            result.AppendLine($"First Context After: {personFirstContext.City}");

            personSecondContext.City = "London";
            result.AppendLine($"Second Context After: {personSecondContext.City}");

            firstContext.SaveChanges();
            result.AppendLine($"First Context Save Changes: 1: {personFirstContext.City} and 2: {personSecondContext.City}");

            secondContext.SaveChanges();
            result.AppendLine($"Second Context Save Changes: 1: {personFirstContext.City} and 2: {personSecondContext.City}");

            return result;
        }

        public static Customer FindById(string id)
        {
            var context = GetContext();

            var customer = context.Customers.Find(id);

            return customer;
        }
    }
}