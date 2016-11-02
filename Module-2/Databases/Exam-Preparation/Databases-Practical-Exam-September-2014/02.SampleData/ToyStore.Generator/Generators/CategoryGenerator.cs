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

    public class CategoryGenerator : DataGenerator, IDataGenerator
    {
        public CategoryGenerator(IRandomGenerator randomGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding categories");
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50)
                };

                this.Database.Categories.Add(category);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }              
            }

            Console.WriteLine("\nCategories added");
        }
    }
}
