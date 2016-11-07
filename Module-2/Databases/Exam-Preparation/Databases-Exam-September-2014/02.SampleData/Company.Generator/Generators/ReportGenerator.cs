namespace Company.Generator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Abstract;
    using Data;
    using Contracts;

    public class ReportGenerator : DataGenerator, IDataGenerator
    {
        public ReportGenerator(IRandomGenerator randomGenerator, CompanyEntities entities, int countOfGeneratedObjects)
            : base(randomGenerator, entities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            // TODO: ReportGenerator

            /*
            var employeeIds = this.Database.Employees
                .Select(e => e.Id)
                .ToList();

            Console.WriteLine("Adding reports");

            for (int i = 0; i < this.Count; i++)
            {
                var report = new Report
                {
                    Time = DateTime.Now.AddDays(this.Random.GetRandomNumber(0, 3560)),
                   
                };
            }

            Console.WriteLine("\nReports added");
            */
        }
    }
}
