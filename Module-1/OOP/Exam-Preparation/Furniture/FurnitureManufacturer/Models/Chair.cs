namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;
    using System.Text;
    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(
                        GlobalErrorMessages.ObjectCannotBeNull,
                        this.GetType().Name));

                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("Number of legs must be more than 0!");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.Append(", Legs: {0}");
            return string.Format(result.ToString(), this.NumberOfLegs);
        }
    }
}
