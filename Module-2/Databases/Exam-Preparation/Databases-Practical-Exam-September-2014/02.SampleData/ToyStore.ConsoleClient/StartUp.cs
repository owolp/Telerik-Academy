namespace ToyStore.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Generator;
    using Generator.Contracts;
    using Generator.Generators;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            var random = RandomGenerator.Instance;
            var db = new ToyStoreEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>()
            {
                new CategoryGenerator(random, db, 100),
                new ManufacturerGenerator(random, db, 50),
                new AgeRangeGenerator(random, db, 100),
                new ToyGenerator(random, db, 2000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
