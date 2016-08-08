namespace ArmyOfCreatures.UnitTests.Logic.Specialities.DoubleDefenseWhenDefending
{
    using System;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ApplyWhenDefending_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheICreaturesInBattleDefenderWithSpecialtyIsNull()
        {
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(10);
            ICreaturesInBattle defenderWithSpecialty = null;
            var mockedAttacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty, mockedAttacker.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheICreaturesInBattleAttackedIsNull()
        {
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(10);
            var mockedDefenderWithSpeciality = new Mock<ICreaturesInBattle>();
            ICreaturesInBattle attacker = null;

            Assert.Throws<ArgumentNullException>(() => doubleDefenseWhenDefending.ApplyWhenDefending(mockedDefenderWithSpeciality.Object, attacker));
        }

        [Test]
        public void ReturnWithoutChangingTheCurrentDefensePropertyOfDefenderWithSpecialty_WhenTheEffectIsExpired()
        {
            int rounds = 5;
            int roundsWithEffectExpired = 10;

            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);
            var mockedDefenderWithSpeciality = new Mock<ICreaturesInBattle>();
            var mockedAttacker = new Mock<ICreaturesInBattle>();

            mockedDefenderWithSpeciality.SetupGet(x => x.CurrentDefense).Returns(It.IsAny<int>());

            for (int i = 0; i < rounds + roundsWithEffectExpired; i++)
            {
                doubleDefenseWhenDefending.ApplyWhenDefending(mockedDefenderWithSpeciality.Object, mockedAttacker.Object);
            }

            mockedDefenderWithSpeciality.VerifySet(x => x.CurrentDefense = It.IsAny<int>(), Times.Exactly(rounds));
        }

        [Test]
        public void ReturnShouldMultiplyTheCurrentDefensePropertyOfDefenderWithSpecialtyByTwo_WhenTheEffectHasNotExpired()
        {
            int defence = 1;
            int rounds = 5;
            int roundsWithEffectExpired = 10;

            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);
            var mockedDefenderWithSpeciality = new Mock<ICreaturesInBattle>();
            var mockedAttacker = new Mock<ICreaturesInBattle>();

            mockedDefenderWithSpeciality.SetupGet(x => x.CurrentDefense).Returns(defence);

            for (int i = 0; i < rounds + roundsWithEffectExpired; i++)
            {
                doubleDefenseWhenDefending.ApplyWhenDefending(mockedDefenderWithSpeciality.Object, mockedAttacker.Object);
            }

            mockedDefenderWithSpeciality.VerifySet(x => x.CurrentDefense = It.Is<int>(y => y == defence * 2), Times.Exactly(rounds));
        }
    }
}