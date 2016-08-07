namespace ArmyOfCreatures.UnitTests.Logic.Battles.BattleManager
{
    using System;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Creatures;
    using NUnit.Framework;
    using Moq;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class AddCreatures_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheCreatureIdentifierIsNull()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 1));
        }

        // var creature = this.creaturesFactory.CreateCreature(creatureIdentifier.CreatureType);
        [Test]
        public void CallCreateCreature_WhenTheCreatureIdentifierIsValid()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            var creatuerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var angel = new Angel();

            mockedCreaturesFactory.Setup(c => c.CreateCreature(It.IsAny<string>())).Returns(angel);

            battleManager.AddCreatures(creatuerIdentifier, 1);

            mockedCreaturesFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Once);
        }
    }
}