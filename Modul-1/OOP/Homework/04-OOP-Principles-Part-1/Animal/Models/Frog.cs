namespace Animal.Models
{
    using System;
    using AbstractModels;
    using Enumerators;

    public class Frog : Animal
    {
        public Frog(string name, int age, GenderType gender)
            : base(name, age, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm a frog!");
        }
    }
}