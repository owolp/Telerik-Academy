namespace School.Models
{
    using AbstractModels;

    public class Teacher : People
    {
        public Teacher(string firstName, string lastName, Discipline discipline)
            : base(firstName, lastName)
        {
            this.Discipline = discipline;
        }

        public Discipline Discipline { get; private set; }
    }
}
