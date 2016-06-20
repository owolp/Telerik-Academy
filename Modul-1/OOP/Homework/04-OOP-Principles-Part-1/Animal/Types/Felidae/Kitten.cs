namespace Animal.Types.Felidae
{
    using System;
    using Enumerators;

    public class Kitten : Cat
    {
        public Kitten(string name, int age, SexType sex)
            : base(name, age, sex)
        {
        }

        public override SexType Sex
        {
            get
            {
                return base.Sex;
            }

            protected set
            {
                if (value == SexType.Male)
                {
                    throw new ArgumentException("Kittens can be only female.");
                }

                base.Sex = value;
            }
        }
    }
}