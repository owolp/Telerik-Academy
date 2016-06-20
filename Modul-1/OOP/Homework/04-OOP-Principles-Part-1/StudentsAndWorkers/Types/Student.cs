namespace StudentsAndWorkers.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AbstractTypes;

    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public virtual List<Student> Order(List<Student> students)
        {
            if (students.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            return students.OrderBy(s => s.FirstName).ToList();
        }

        public override string ToString()
        {
            return string.Format(this.FirstName + " " + this.LastName + " {0}", this.Grade);
        }
    }
}
