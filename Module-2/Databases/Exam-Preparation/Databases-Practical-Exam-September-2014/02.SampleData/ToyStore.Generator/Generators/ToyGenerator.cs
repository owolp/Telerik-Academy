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

    public class ToyGenerator : DataGenerator, IDataGenerator
    {
        public ToyGenerator(IRandomGenerator randomGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var ageRangeIds = this.Database.AgeRanges
                .Select(a => a.Id)
                .ToList();
            var manufacturerIds = this.Database.Manufacturers
                .Select(m => m.Id)
                .ToList();
            var categoryIds = this.Database.Categories
                .Select(c => c.Id)
                .ToList();

            Console.WriteLine("Adding toys");
            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Type = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Price = this.Random.GetRandomNumber(10, 500),
                    Color = this.Random.GetRandomStringWithRandomLength(5, 20),
                    // Color = this.Random.GetRandomNumber(1, 5) == 5 ? null : this.Random.GetRandomStringWithRandomLength(5, 20),
                    // Color = this.Random.GetRandomNumber(0, 100) < 65 ? null : this.Random.GetRandomStringWithRandomLength(5, 20)
                    ManufacturerId = manufacturerIds[this.Random.GetRandomNumber(0, manufacturerIds.Count - 1)],
                    AgeRangeId = ageRangeIds[this.Random.GetRandomNumber(0, ageRangeIds.Count - 1)]
                };

                
                if (categoryIds.Count > 0)
                {
                    var uniqueCategoryIds = new HashSet<int>();
                    var categoriesInToy = this.Random.GetRandomNumber(1, Math.Min(10, categoryIds.Count));

                    while (uniqueCategoryIds.Count != categoriesInToy)
                    {
                        uniqueCategoryIds.Add(categoryIds[this.Random.GetRandomNumber(0, categoryIds.Count - 1)]);
                    }

                    foreach (var uniqueCategoryId in uniqueCategoryIds)
                    {
                        toy.Categories.Add(this.Database.Categories.Find(uniqueCategoryId));
                    }
                }

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Toys.Add(toy);

            }
            Console.WriteLine("\nToys added");
        }
    }
}
