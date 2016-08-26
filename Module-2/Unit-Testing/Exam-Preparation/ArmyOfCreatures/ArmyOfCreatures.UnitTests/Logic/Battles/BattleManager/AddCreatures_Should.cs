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

        // var creaturesInBattle = new CreaturesInBattle(creature, count);
        // This should work, as creature has been tested
        // I think that count should be tested as well

        // this.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
        // Do not test - as mocking the object under test is not allowed

        [Test]
        public void CallTheLogger_WhenTheCreatureIdentifierIsValid()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var battleManager = new BattleManager(mockedCreaturesFactory.Object, mockedLogger.Object);

            var creatuerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var angel = new Angel();

            mockedCreaturesFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(angel);

            battleManager.AddCreatures(creatuerIdentifier, 1);

            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}