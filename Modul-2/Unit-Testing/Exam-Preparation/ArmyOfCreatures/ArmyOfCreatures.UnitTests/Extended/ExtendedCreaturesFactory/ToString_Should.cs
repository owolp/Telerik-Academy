namespace ArmyOfCreatures.UnitTests.Extended.ExtendedCreaturesFactory
{
    using System;
    using ArmyOfCreatures.Logic.Battles;
    using NUnit.Framework;

    [TestFixture]
    public class ToString_Should
    {
        [Test]
        public void ReturnExpectedResult_WhenValidValueIsProvided()
        {
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(1)");

            var expectedResult = "AncientBehemoth(1)";

            var actualResult = creatureIdentifier.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}