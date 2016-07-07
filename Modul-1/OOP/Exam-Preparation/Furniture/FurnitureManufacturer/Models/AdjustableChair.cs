﻿namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            Validator.CheckIfNull(
                height,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull,
                    this.GetType().Name));

            this.Height = height;
        }
    }
}
