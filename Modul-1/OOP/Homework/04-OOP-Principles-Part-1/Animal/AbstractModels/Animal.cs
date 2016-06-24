namespace Animal.AbstractModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enumerators;
    using Interfaces;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private GenderType gender;

        public Animal(string name, int age, GenderType gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public virtual GenderType Gender
        {
            get { return this.gender; }
            protected set { this.gender = value; }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The age can not be negative.");
                }

                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name can not be empty.");
                }

                this.name = value;
            }
        }

        public static double AverageAge(List<Animal> animals, Type type)
        {
            var totalAge = animals.Where(a => a.GetType() == type).Select(a => a.Age).ToList();

            return (double)totalAge.Sum() / totalAge.Count();
        }

        public abstract void MakeSound();
    }
}