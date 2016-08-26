namespace Animal.Models.Felidae
{
    using System;
    using Enumerators;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, GenderType sex)
            : base(name, age, sex)
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
                if (value == GenderType.Female)
                {
                    throw new ArgumentException("Tomcats can be only Male.");
                }

                base.Gender = value;
            }
        }
    }
}