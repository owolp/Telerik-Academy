namespace Animal.Types
{
    using System;
    using AbstractTypes;
    using Enumerators;

    public class Frog : Animal
    {
        public Frog(string name, int age, SexType sex)
            : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm a frog!");
        }
    }
}