namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;
    using System.Text;
    public abstract class Furniture : IFurniture
    {
        private const int MinModelLength = 3;

        private decimal height;
        private string model;
        private decimal price;
        private readonly MaterialType materialType;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.materialType = material;
            this.Price = price;
            this.Height = height;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(
                        GlobalErrorMessages.ObjectCannotBeNull,
                        this.GetType().Name));

                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("•	Height cannot be less or equal to 0.00 m!");
                }

                this.height = value;
            }
        }

        public string Material
        {
            get
            {
                return this.materialType.ToString();
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        this.GetType().Name));

                                Validator.CheckIfStringMinLengthIsValid(
                                    value,
                                    MinModelLength,
                                    string.Format(
                                        GlobalErrorMessages.InvalidStringMinLength,
                                        this.GetType().Name,
                                        MinModelLength));

                    this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(
                        GlobalErrorMessages.ObjectCannotBeNull,
                        this.GetType().Name));

                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("Price cannot be less or equal to $0.00!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(
                string.Format(
                    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                    this.GetType().Name,
                    this.Model,
                    this.Material,
                    this.Price,
                    this.Height));

            return result.ToString().Trim();
        }
    }
}
