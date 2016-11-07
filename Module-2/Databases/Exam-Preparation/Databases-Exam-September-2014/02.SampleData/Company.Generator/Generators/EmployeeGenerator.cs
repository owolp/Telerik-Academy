namespace Company.Generator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Data;
    using Contracts;

    public class EmployeeGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeGenerator(IRandomGenerator randomGenerator, CompanyEntities entities, int countOfGeneratedObjects)
            : base(randomGenerator, entities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var departmentIds = this.Database.Departments
                .Select(d => d.Id)
                .ToList();

            var allAddedEmployees = new List<Employee>();

            Console.WriteLine("Adding Employees");
            for (int i = 0; i < this.Count; i++)
            {
                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    YearSalary = this.Random.GetRandomNumber(50000, 200000),
                    DepartmentId = departmentIds[this.Random.GetRandomNumber(0, departmentIds.Count - 1)]
                };

                if (allAddedEmployees.Count > 0 && this.Random.GetRandomNumber(1, 100) <= 95)
                {
                    employee.Employee1 = allAddedEmployees[this.Random.GetRandomNumber(0, allAddedEmployees.Count - 1)];
                }

                allAddedEmployees.Add(employee);

                this.Database.Employees.Add(employee);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }
            Console.WriteLine("\nEmployees added");
        }
    }
}
