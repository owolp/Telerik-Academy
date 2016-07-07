namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;
    using System.Text;
    public class Company : ICompany
    {
        private const int MinNameLength = 5;
        private const int MaxNameLength = 100;
        private const int RegistrationNumberLength = 10;

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                // Return new List in order to return a copy of the original one
                return new List<IFurniture>(this.furnitures);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
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
                    MinNameLength,
                    string.Format(
                        GlobalErrorMessages.InvalidStringMinLength,
                        this.GetType().Name,
                        MinNameLength));

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                Validator.CheckIfStringLengthIsWithExactLength(
                    value,
                    RegistrationNumberLength,
                    string.Format(
                        GlobalErrorMessages.InvalidStringExactLength,
                            this.GetType().Name,
                            RegistrationNumberLength));

                Validator.CheckIfStringContainsOnlyDigits(
                    value,
                    string.Format(
                        GlobalErrorMessages.InvalidStringDigits,
                        this.GetType().Name));

                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            Validator.CheckIfNull(
                furniture,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull,
                    this.furnitures.GetType().Name));

            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var furnitureCalatalogInfo = string.Empty;

            StringBuilder result = new StringBuilder();

            result.AppendLine(
                string.Format(
                    "{0} - {1} - {2} {3}",
                    this.Name,
                    this.RegistrationNumber,
                    this.Furnitures.Count == 0 ? "no" : this.Furnitures.Count.ToString(),
                    this.Furnitures.Count == 1 ? "furniture" : "furnitures"));

            var orderedFurniture = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);

            foreach (var furniture in orderedFurniture)
            {
                result.AppendLine(furniture.ToString());
            }

            return result.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public void Remove(IFurniture furniture)
        {
            Validator.CheckIfNull(
                furniture,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull,
                    this.furnitures.GetType().Name));

            this.furnitures.Remove(furniture);
        }
    }
}
