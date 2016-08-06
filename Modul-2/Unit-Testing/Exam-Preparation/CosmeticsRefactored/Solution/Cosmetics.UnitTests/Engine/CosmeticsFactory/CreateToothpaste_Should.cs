namespace Cosmetics.UnitTests.Engine.CosmeticsFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cosmetics.Common;
    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CreateToothpaste_Should
    {
        // CreateToothpaste should throw NullReferenceException, when the passed "name" parameter is invalid. (Null or Empty)
        [TestCase("")]
        [TestCase(null)]
        public void ThrowNullReferenceException_WhenTheNameParamIsInvalid(string nameToTest)
        {
            var toothpaste = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => toothpaste.CreateToothpaste(nameToTest, "validBrand", 10.0M, GenderType.Men, new List<string>() { "firstParam", "secondParam" }));
        }

        // CreateToothpaste should throw IndexOutOfRangeException, when the passed "name" parameter is invalid. (length out of range)
        [TestCase("a")]
        [TestCase("20CharactersLongText")]
        public void ThrowIndexOutOfRangeException_WhenNameParamIsWithInvalidRange(string nameToTest)
        {
            var toothpaste = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => toothpaste.CreateToothpaste(nameToTest, "validBrand", 10.0M, GenderType.Men, new List<string>() { "firstParam", "secondParam" }));
        }

        // CreateToothpaste should throw NullReferenceException, when the passed "brand" parameter is invalid. (Null or Empty)
        [TestCase("")]
        [TestCase(null)]
        public void ThrowNullReferenceException_WhenTheBrandParamIsInvalid(string brandToTest)
        {
            var toothpaste = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => toothpaste.CreateToothpaste("validName", brandToTest, 10.0M, GenderType.Men, new List<string>() { "firstParam", "secondParam" }));
        }

        // CreateToothpaste should throw IndexOutOfRangeException, when the passed "brand" parameter is invalid. (length out of range)
        [TestCase("a")]
        [TestCase("20CharactersLongText")]
        public void ThrowIndexOutOfRangeException_WhenBrandParamIsWithInvalidRange(string brandToTest)
        {
            var toothpaste = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => toothpaste.CreateToothpaste("validName", brandToTest, 10.0M, GenderType.Men, new List<string>() { "firstParam", "secondParam" }));
        }

        // CreateToothpaste should throw IndexOutOfRangeException, when the lenght of any item's name is not in the allowed boundaries.
        [TestCase("a", "a")]
        [TestCase("20CharactersLongText", "20CharactersLongText")]
        public void ThrowIndexOutOfRangeException_WhenNameAndBrandParamIsWithInvalidRange(params string[] ingredients)
        {
            var toothpaste = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => toothpaste.CreateToothpaste("validName", "validBrand", 10.0M, GenderType.Men, ingredients.ToList()));
        }
    }
}