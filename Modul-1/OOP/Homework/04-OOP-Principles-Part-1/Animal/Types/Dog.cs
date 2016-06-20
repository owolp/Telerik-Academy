namespace Animal.Types
{
    using System;
    using AbstractTypes;
    using Enumerators;

    public class Dog : Animal
    {
        public Dog(string name, int age, SexType sex)
            : base(name, age, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("I'm a dog!");
        }
    }
}
