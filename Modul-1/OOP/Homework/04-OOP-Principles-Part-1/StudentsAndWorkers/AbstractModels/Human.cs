namespace StudentsAndWorkers.AbstractModels
{
    using System.Collections.Generic;

    public abstract class Human
    {
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName { get; private set; }

        public string FirstName { get; private set; }

        public virtual IEnumerable<Human> Order()
        {
            return new List<Human>();
        }

        public override string ToString()
        {
            return string.Format(this.FirstName + " " + this.LastName);
        }
    }
}
