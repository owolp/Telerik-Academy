namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private const int MinimumNameLength = 2;
        private const int MaximumNameLength = 15;

        private ICollection<IProduct> productsList;
        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.productsList = new List<IProduct>();
        }

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
                    MaximumNameLength,
                    MinimumNameLength,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        this.GetType().Name + " name",
                        MinimumNameLength,
                        MaximumNameLength));

                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        this.GetType().Name + " name"));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(
                cosmetics,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull,
                        "Cosmetics add to category"));
            this.productsList.Add(cosmetics);
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(
                string.Format(
                    "{0} category - {1} {2} in total",
                    this.Name,
                    this.productsList.Count,
                    this.productsList.Count == 1 ? "product" : "products"));

            // var sortedProductsList = this.SortProductList(this.productsList);
            var sortedProductsList = this.productsList
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price);

            foreach (var product in sortedProductsList)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(
                cosmetics,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull,
                        "Remove cosmetics from category"));

            if (!this.productsList.Contains(cosmetics))
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Product {0} does not exist in category {1}!",
                        cosmetics.Name,
                    this.GetType().Name));
            }

            this.productsList.Remove(cosmetics);
        }

        public IEnumerable<IProduct> SortProductList(ICollection<IProduct> productsList)
        {
            return this.productsList
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price);
        }
    }
}