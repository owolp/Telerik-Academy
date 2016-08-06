namespace Cosmetics.UnitTests.Products.Toothpaste
{
    using System.Collections.Generic;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Products;
    using NUnit.Framework;

    [TestFixture]
    public class Print_Should
    {
        // Toothpaste.Print() should return a string with the toothpaste details in the required format.
        [Test]
        public void ReturnValidStringWithToothpasteDetails()
        {
            var shampoo = new Toothpaste("validName", "validBrand", 10M, GenderType.Unisex, new List<string>() { "firstParam", "secondParam" });
            
            var sb = new StringBuilder();
            sb.AppendLine("- validBrand - validName:");
            sb.AppendLine("  * Price: $10");
            sb.AppendLine("  * For gender: Unisex");
            sb.Append("  * Ingredients: firstParam, secondParam");

            var expected = sb.ToString();

            var actual = shampoo.Print();

            Assert.AreEqual(expected, actual);
        }
    }
}