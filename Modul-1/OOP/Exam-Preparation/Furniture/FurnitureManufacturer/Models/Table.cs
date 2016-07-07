namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;
    using System.Text;
    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return this.length * this.width;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(
                        GlobalErrorMessages.ObjectCannotBeNull,
                        this.GetType().Name));

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(
                        GlobalErrorMessages.ObjectCannotBeNull,
                        this.GetType().Name));

                this.width = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.Append(", Length: {0}, Width: {1}, Area: {2}");
            return string.Format(result.ToString(), this.Length, this.Width, this.Area);
        }
    }
}
