namespace Person.Models
{
    using System.Text;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Age = null;
        }

        public Person(string name, int? age)
            : this(name)
        {
            this.Age = age;
        }

        public string Name { get; private set; }

        public int? Age { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("Name: {0}", this.Name));

            if (this.Age != null)
            {
                result.AppendLine(string.Format("Age: {0}", this.Age));
            }
            else
            {
                result.AppendLine("Age: Not Specified");
            }

            return result.ToString();
        }
    }
}
