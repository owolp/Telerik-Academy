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

    public class AgeRangeGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangeGenerator(IRandomGenerator randomGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomGenerator, toyStoreEntities, countOfGeneratedObjects)

        {
        }

        public override void Generate()
        {
            int count = 0;
            Console.WriteLine("Adding age ranges");
            for (int i = 0; i < this.Count / 5; i++)
            {
                for (int j = i + 1; j <= i + 5; j++)
                {
                    var ageRange = new AgeRanx
                    {
                        MinAge = i,
                        MaxAge = j
                    };

                    this.Database.AgeRanges.Add(ageRange);

                    count++;
                    if (count == this.Count)
                    {
                        return;
                    }

                    if (count % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }
                }
            }

            Console.WriteLine("\nAge ranges added");
        }
    }
}
