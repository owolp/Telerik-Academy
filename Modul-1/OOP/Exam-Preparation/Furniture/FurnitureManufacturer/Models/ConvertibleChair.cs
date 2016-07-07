namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;
    using System.Text;
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedStateSetHeight = 0.10m;

        private decimal nonConvertedHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.nonConvertedHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (IsConverted)
            {
                this.Height = this.nonConvertedHeight;
            }
            else
            {
                this.Height = ConvertedStateSetHeight;
            }

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.Append(", State: {0}");
            return string.Format(result.ToString(), this.IsConverted ? "Converted" : "Normal");
        }
    }
}
