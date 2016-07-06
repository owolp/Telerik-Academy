namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Contracts;

    public class Shampoo : Product, IShampoo, IProduct
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price *= this.Milliliters;
        }

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.Print());

            result.AppendLine(
                string.Format(
                    "  * Quantity: {0} ml", this.Milliliters));

            result.AppendLine(
                string.Format(
                    "  * Usage: {0}", this.Usage));

            return result.ToString().Trim();
        }
    }
}
