namespace School.Models
{
    using AbstractModels;

    public class Student : People
    {
        private int uniqueNumber;

        public Student(string firstName, string lastName, int uniqueNumber)
            : base(firstName, lastName)
        {
            this.UniqueNumber = uniqueNumber;
        }

        public int UniqueNumber
        {
            get { return this.uniqueNumber; }
            set { this.uniqueNumber = value; }
        }
    }
}
