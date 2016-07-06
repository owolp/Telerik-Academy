namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System;
    using System.Text;
    public abstract class Product : IProduct
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 10;
        private const int MinBrandLength = 2;
        private const int MaxBrandLength = 10;

        private string name;
        private string brand;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    MaxBrandLength,
                    MinBrandLength,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Product brand", MinBrandLength, MaxBrandLength
                        ));

                Validator.CheckIfStringIsNullOrEmpty(
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product brand"));

                this.brand = value;
            }
        }

        public GenderType Gender { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    MaxNameLength,
                    MinNameLength,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Product name",
                        MinNameLength,
                        MaxNameLength));

                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        this.GetType().Name + " name"));

                this.name = value;
            }
        }

        public decimal Price { get; protected set; }

        public virtual string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(
                string.Format(
                    "- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(
                string.Format(
                    "  * Price: ${0}", this.Price));
            result.AppendLine(
                string.Format(
                    "  * For gender: {0}", this.Gender));

            return result.ToString().Trim();
        }
    }
}