namespace Cosmetics.UnitTests.Engine.CosmeticsFactory
{
    using System;
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CreateShampoo_Should
    {
        /* CreateShampoo should throw NullReferenceException,
         * when the passed "name" parameter is invalid. (Null or Empty)
         */
        [TestCase("")]
        [TestCase(null)]
        public void ThrowNullReferenceException_WhenThePassedNameParamIsNullOrEmpty(string nameToTest)
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateShampoo(nameToTest, "brandName", 10.0M, GenderType.Men, 10, UsageType.EveryDay));
        }

        /* CreateShampoo should throw IndexOutOfRangeException,
         * when the passed "name" parameter is invalid. (length out of range)
         */
        [TestCase("ab")]
        [TestCase("20CharactersLongText")]
        public void ThrowIndexOutOfRangeException_WhenThePassedNameParamIsInvalid(string nameToTest)
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateShampoo(nameToTest, "brandName", 10.0M, GenderType.Men, 10, UsageType.EveryDay));
        }

        /* CreateShampoo should throw NullReferenceException,
         * when the passed "brand" parameter is invalid. (Null or Empty)
         */
        [TestCase("")]
        [TestCase(null)]
        public void ThrowNullReferenceException_WhenThePassedBrandParamIsNullOrEmpty(string brandToTest)
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateShampoo("validName", brandToTest, 10.0M, GenderType.Men, 10, UsageType.EveryDay));
        }

        /* CreateShampoo should throw IndexOutOfRangeException,
         * when the passed "brand" parameter is invalid. (length out of range)
         */
        [TestCase("a")]
        [TestCase("20CharactersLongText")]
        public void ThrowIndexOutOfRangeException_WhenThePassedBrandParamIsInvalid(string brandToTest)
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateShampoo("validName", brandToTest, 10.0M, GenderType.Men, 10, UsageType.EveryDay));
        }

        /* CreateShampoo should return a new Shampoo, when the passed parameters are all valid.
         */

        [Test]
        public void ReturnNewShampoo_WhenThePassedParametersAreAllValid()
        {
            var cosmeticsFactory = new CosmeticsFactory();
            var shampoo = cosmeticsFactory.CreateShampoo("validName", "validBrand", 10.0M, GenderType.Men, 10, UsageType.EveryDay);

            Assert.IsInstanceOf<IShampoo>(shampoo);
        }
    }
}