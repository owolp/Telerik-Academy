namespace School.Models
{
    using AbstractModels;

    public class Student : People
    {
        public Student(string firstName, string lastName, int uniqueNumber)
            : base(firstName, lastName)
        {
            this.UniqueNumber = uniqueNumber;
        }

        public int UniqueNumber { get; private set; }
    }
}
