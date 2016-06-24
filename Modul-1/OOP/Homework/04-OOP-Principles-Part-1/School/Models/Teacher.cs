namespace School.Models
{
    using AbstractModels;

    public class Teacher : People
    {
        private Discipline discipline;

        public Teacher(string firstName, string lastName, Discipline discipline)
            : base(firstName, lastName)
        {
            this.Discipline = discipline;
        }

        public Discipline Discipline
        {
            get { return this.discipline; }
            set { this.discipline = value; }
        }
    }
}
