namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Contracts;
    using System.Text;
    using System.Linq;
    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngredientLength = 4;
        private const int MaxIngredientLength = 12;

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }

            private set
            {
                var ingredientsAsList = value.Split(',').ToList();

                foreach (var ingredient in ingredientsAsList)
                {
                    var ingredientTrimmed = ingredient.Trim();

                    Validator.CheckIfStringLengthIsValid(
                        ingredientTrimmed,
                        MaxIngredientLength,
                        MinIngredientLength,
                        string.Format(
                            GlobalErrorMessages.InvalidStringLength,
                                "Each ingredient",
                                MinIngredientLength,
                                MaxIngredientLength));
                }

                this.ingredients = value;
            }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.Print());

            result.AppendLine(
                string.Format(
                    "  * Ingredients: {0}", this.Ingredients));

            return result.ToString().Trim();
        }
    }
}
