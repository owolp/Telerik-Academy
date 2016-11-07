namespace Company.Generator.Generators
{
    using System;
    using Abstract;
    using Data;
    using Contracts;

    public class DepartmentGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentGenerator(IRandomGenerator randomGenerator, CompanyEntities entities, int countOfGeneratedObjects)
            : base(randomGenerator, entities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding departments");
            for (int i = 0; i < this.Count; i++)
            {
                var department = new Department
                {
                    Name = this.Random.GetRandomStringWithRandomLength(10, 50)
                };

                this.Database.Departments.Add(department);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nDepartments added");
        }
    }
}
