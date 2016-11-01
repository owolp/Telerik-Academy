namespace NorthWindApp
{
    using System.Linq;
    using NorthWindData.DataModels;
    using NorthWindData.Models;

    internal class Program
    {
        private static void Main()
        {
            var dbContext = new NorthwindDbContext();

            var country = dbContext.Countries.FirstOrDefault(c => c.Id == 1);

            System.Console.WriteLine(country);
        }
    }
}