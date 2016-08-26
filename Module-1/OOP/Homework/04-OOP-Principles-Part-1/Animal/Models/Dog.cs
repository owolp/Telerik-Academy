namespace Animal.Models
{
    using System;
    using AbstractModels;
    using Enumerators;

    public class Dog : Animal
    {
        public Dog(string name, int age, GenderType gender)
            : base(name, age, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm a dog!");
        }
    }
}
