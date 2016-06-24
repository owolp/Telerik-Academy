namespace StudentsAndWorkers.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AbstractModels;

    public class Student : Human
    {
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade { get; private set; }

        public virtual List<Student> Order(IEnumerable<Student> students)
        {
            if (students.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            return students.OrderBy(s => s.FirstName).ToList();
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + " {0}", this.Grade);
        }
    }
}
