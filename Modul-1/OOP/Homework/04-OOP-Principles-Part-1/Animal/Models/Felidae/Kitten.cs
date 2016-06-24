namespace Animal.Models.Felidae
{
    using System;
    using Enumerators;

    public class Kitten : Cat
    {
        public Kitten(string name, int age, GenderType gender)
            : base(name, age, gender)
        {
        }

        public override GenderType Gender
        {
            get
            {
                return base.Gender;
            }

            protected set
            {
                if (value == GenderType.Male)
                {
                    throw new ArgumentException("Kittens can be only female.");
                }

                base.Gender = value;
            }
        }
    }
}