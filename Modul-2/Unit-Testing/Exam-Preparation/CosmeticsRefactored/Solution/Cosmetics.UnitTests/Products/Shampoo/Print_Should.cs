namespace Cosmetics.UnitTests.Products.Shampoo
{
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Products;
    using NUnit.Framework;

    [TestFixture]
    public class Print_Should
    {
        // Shampoo.Print() should return a string with the shampoo details in the required format.
        [Test]
        public void ReturnValidStringWithShampooDetails()
        {
            var shampoo = new Shampoo("validName", "validBrand", 10M, GenderType.Unisex, 100, UsageType.EveryDay);

            var sb = new StringBuilder();
            sb.AppendLine("- validBrand - validName:");
            sb.AppendLine("  * Price: $1000");
            sb.AppendLine("  * For gender: Unisex");
            sb.AppendLine("  * Quantity: 100 ml");
            sb.Append("  * Usage: EveryDay");

            var expected = sb.ToString();

            var actual = shampoo.Print();

            Assert.AreEqual(expected, actual);
        }
    }
}