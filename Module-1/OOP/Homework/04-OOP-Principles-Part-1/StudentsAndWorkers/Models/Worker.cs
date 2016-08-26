namespace StudentsAndWorkers.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AbstractModels;

    public class Worker : Human
    {
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WorkHoursPerDay { get; private set; }

        public int WeekSalary { get; private set; }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }

        public virtual List<Worker> Order(IEnumerable<Worker> workers)
        {
            if (workers.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            return workers.OrderByDescending(w => w.MoneyPerHour()).ToList();
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + " {0}", this.MoneyPerHour());
        }
    }
}