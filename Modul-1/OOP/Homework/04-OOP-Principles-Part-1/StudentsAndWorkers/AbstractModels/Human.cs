namespace StudentsAndWorkers.AbstractModels
{
    using System.Collections.Generic;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public virtual List<Human> Order()
        {
            return new List<Human>();
        }

        public override string ToString()
        {
            return string.Format(this.FirstName + " " + this.LastName);
        }
    }
}
