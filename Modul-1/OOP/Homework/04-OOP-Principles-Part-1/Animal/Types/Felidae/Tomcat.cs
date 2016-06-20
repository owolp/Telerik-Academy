namespace Animal.Types.Felidae
{
    using System;
    using Enumerators;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, SexType sex)
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
                if (value == SexType.Female)
                {
                    throw new ArgumentException("Tomcats can be only Male.");
                }

                base.Sex = value;
            }
        }
    }
}