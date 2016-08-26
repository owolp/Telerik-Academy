namespace ArmyOfCreatures.UnitTests.Logic.Battles.CreatureIdentifier
{
    using System;
    using ArmyOfCreatures.Logic.Battles;
    using NUnit.Framework;

    [TestFixture]
    public class CreatureIdentifierFromString_Should
    {
        [Test]
        public void ReturnArgumentNullException_WhenTheInputValueIsNull()
        {
            string valueToParse = null;

            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse));
        }

        [Test]
        public void ReturnException_WhenTheInputValueIntIsInvalid()
        {
            string valueToParse = "AncientBehemoth(N/A)";

            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse));
        }

        [Test]
        public void ReturnIndexOutOfRangeException_WhenTheInputValueStringIsInvalid()
        {
            string valueToParse = "AncientBehemoth";

            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse));
        }

        [Test]
        public void ReturnNewCreatureIdentifier_WhenTheInputValueIsInTheCorrectFormat()
        {
            string valueToParse = "AncientBehemoth(1)";

            var actual = CreatureIdentifier.CreatureIdentifierFromString(valueToParse);

            Assert.IsInstanceOf<CreatureIdentifier>(actual);
        }

        [Test]
        public void ReturnCreatureType_WhenTheInputValueIsInTheCorrectFormat()
        {
            string valueToParse = "AncientBehemoth(1)";
            var expectedCreatureType = "AncientBehemoth";

            var actual = CreatureIdentifier.CreatureIdentifierFromString(valueToParse);

            Assert.AreEqual(expectedCreatureType, actual.CreatureType);
        }

        [Test]
        public void ReturnArmyNumber_WhenTheInputValueIsInTheCorrectFormat()
        {
            string valueToParse = "AncientBehemoth(1)";
            var expectedArmyNumber = 1;

            var actual = CreatureIdentifier.CreatureIdentifierFromString(valueToParse);

            Assert.AreEqual(expectedArmyNumber, actual.ArmyNumber);
        }
    }
}