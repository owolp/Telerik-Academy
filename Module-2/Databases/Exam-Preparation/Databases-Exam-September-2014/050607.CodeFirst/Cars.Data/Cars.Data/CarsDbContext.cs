namespace Cars.Data
{
    using System.Data.Entity;
    using Models;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("Cars")
        {
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}