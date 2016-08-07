namespace ArmyOfCreatures.UnitTests.Extended.ExtendedCreaturesFactory
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic.Creatures;
    using NUnit.Framework;

    [TestFixture]
    public class CreateCreature_Should
    {
        [TestCase("Angel", typeof(Angel))]
        [TestCase("Archangel", typeof(Archangel))]
        [TestCase("ArchDevil", typeof(ArchDevil))]
        [TestCase("Behemoth", typeof(Behemoth))]
        [TestCase("Devil", typeof(Devil))]
        [TestCase("AncientBehemoth", typeof(AncientBehemoth))]
        [TestCase("CyclopsKing", typeof(CyclopsKing))]
        [TestCase("Griffin", typeof(Griffin))]
        [TestCase("WolfRaider", typeof(WolfRaider))]
        [TestCase("Goblin", typeof(Goblin))]
        public void RetursnNewCreate_WhenThePassedParametersAreCorrect(string creatureName, Type expectedCreatureType)
        {
            var factory = new ExtendedCreaturesFactory();

            var actual = factory.CreateCreature(creatureName);

            Assert.IsInstanceOf(expectedCreatureType, actual);
        }

        [TestCase("NonValidCreature")]
        [TestCase("Ang3l")]
        public void ReturnsArgumentException_WhenThePassedParametersAreInvalid(string creatureName)
        {
            var factory = new ExtendedCreaturesFactory();

            Assert.Throws<ArgumentException>(() => factory.CreateCreature(creatureName));
        }

        [TestCase("NonValidCreature")]
        [TestCase("Ang3l")]
        public void ReturnsTrue_WhenThePassedParametersAreInvalid(string creatureName)
        {
            var factory = new ExtendedCreaturesFactory();
            var expected = string.Format(CultureInfo.InvariantCulture, "Invalid creature type \"{0}\"!", creatureName);

            var actual = Assert.Throws<ArgumentException>(() => factory.CreateCreature(creatureName));

            StringAssert.Contains(expected, actual.Message);
        }
    }
}