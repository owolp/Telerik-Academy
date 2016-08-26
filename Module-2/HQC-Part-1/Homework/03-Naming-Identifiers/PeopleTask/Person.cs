namespace PeopleTask
{
    using Enums;

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public void CreatePerson(int age)
        {
            Person person = new Person();
            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "The Big Guy";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "The Good Looking Lady";
                person.Gender = Gender.Female;
            }
        }
    }
}
