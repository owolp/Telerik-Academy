namespace NorthWindDataModels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NorthWindData.Models;

    public sealed class Configuration : DbMigrationsConfiguration<NorthWindData.DataModels.NorthwindDbContext>
    {
        public Configuration()
        {
            // в product никога не се слага true, защото нямам контрол, винаги седи false
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NorthWindData.DataModels.NorthwindDbContext context)
        {
            if (!context.Teachers.Any())
            {

            }
        }
    }
}
