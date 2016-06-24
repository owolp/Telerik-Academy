namespace StudentsAndWorkers.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AbstractModels;

    public class Worker : Human
    {
        private int weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set { this.workHoursPerDay = value; }
        }

        public int WeekSalary
        {
            get { return this.weekSalary; }
            set { this.weekSalary = value; }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }

        public virtual List<Worker> Order(List<Worker> workers)
        {
            if (workers.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            return workers.OrderByDescending(w => w.MoneyPerHour()).ToList();
        }

        public override string ToString()
        {
            return string.Format(this.FirstName + " " + this.LastName + " {0}", this.MoneyPerHour());
        }
    }
}