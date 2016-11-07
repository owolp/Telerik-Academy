namespace Company.ConsoleClient
{
    using System.Collections.Generic;
    using Data;
    using Generator;
    using Generator.Contracts;
    using Generator.Generators;

    public class StartUp
    {
        public static void Main()
        {
            var random = RandomGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>()
            {
                // new DepartmentGenerator(random, db, 100),
                new EmployeeGenerator(random, db, 5000),
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
