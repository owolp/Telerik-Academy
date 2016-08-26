namespace Animal.Models
{
    using System;
    using AbstractModels;
    using Enumerators;

    public class Cat : Animal
    {
        public Cat(string name, int age, GenderType gender)
            : base(name, age, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm a cat!");
        }
    }
}