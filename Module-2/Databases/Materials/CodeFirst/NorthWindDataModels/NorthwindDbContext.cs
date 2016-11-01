namespace NorthWindData.DataModels
{
    using System.Data.Entity;
    using Models;

    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
            : base("NorthwindDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasKey(x => x.Id).HasMany(x => x.Teachers).WithRequired(x => x.HomeCity);

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Teacher> Teachers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }
    }
}