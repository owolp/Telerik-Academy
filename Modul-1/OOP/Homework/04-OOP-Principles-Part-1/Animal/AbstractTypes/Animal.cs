namespace Animal.AbstractTypes
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
        private SexType sex;

        public Animal(string name, int age, SexType sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public virtual SexType Sex
        {
            get { return this.sex; }
            protected set { this.sex = value; }
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

        public virtual void MakeSound()
        {
        }
    }
}