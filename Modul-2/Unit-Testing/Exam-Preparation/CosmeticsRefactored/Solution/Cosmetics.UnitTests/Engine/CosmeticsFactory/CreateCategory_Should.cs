namespace Cosmetics.UnitTests.Engine.CosmeticsFactory
{
    using System;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CreateCategory_Should
    {
        /* CreateCategory should throw NullReferenceException,
         * when the passed "name" parameter is invalid. (Null or Empty)
         */
        [TestCase("")]
        [TestCase(null)]
        public void ThrowNullReferenceException_WhenTheNameParamIsNullOrEmpty(string text)
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => cosmeticsFactory.CreateCategory(text));
        }

        /* CreateCategory should throw IndexOutOfRangeException,
         * when the passed "name" parameter is invalid. (length out of range)
         */
        [TestCase("a")]
        [TestCase("20CharactersLongText")]
        public void ThrowIndexOutOfRangeException_WhenThePassedNameParamIsInvalid(string categoryName)
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => cosmeticsFactory.CreateCategory(categoryName));
        }

        /* CreateCategory should return a new Category, when the passed parameters are all valid. 
         */
        [Test]
        public void ReturnNewCategory_WhenAllPassedParametersAreValid()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            var newCosmeticsFactory = cosmeticsFactory.CreateCategory("validName");

            Assert.IsInstanceOf<ICategory>(newCosmeticsFactory);
        }
    }
}