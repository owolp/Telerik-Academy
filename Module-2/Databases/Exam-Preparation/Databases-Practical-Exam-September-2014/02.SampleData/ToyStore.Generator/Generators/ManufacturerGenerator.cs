namespace ToyStore.Generator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Abstract;
    using Contracts;
    using Data;

    public class ManufacturerGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerGenerator(IRandomGenerator randomGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();

            while (manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(5, 50));
            }

            var index = 0;
            Console.WriteLine("Adding manufacturers");
            foreach (var manufacturerName in manufacturersToBeAdded)
            {
                var manufacturer = new Manufacturer
                {
                    Name = manufacturerName,
                    Country = this.Random.GetRandomStringWithRandomLength(2, 50)
                };

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                index++;

                this.Database.Manufacturers.Add(manufacturer);
            }

            Console.WriteLine("\nManufacturers added");
        }
    }
}
