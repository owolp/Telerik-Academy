namespace ArmyOfCreatures.UnitTests.Console.Commands.AddCommand
{
    using System;
    using ArmyOfCreatures.Console.Commands;
    using NUnit.Framework;
    using Moq;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class ProcessCommand_Should
    {
        [Test]
        public void ThrowArgumentNullExpeption_WhenTheIBattleManagerIsNull()
        {
            var addCommand = new AddCommand();
            IBattleManager battleManager = null;
            string[] arguments = new string[] { "10", "AncientBehemoth(1)" };

            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(battleManager, arguments));
        }

        [Test]
        public void ThrowArgumentNullExpeption_WhenTheParamsIsNull()
        {
            var addCommand = new AddCommand();
            var mockedBattleManager = new Mock<IBattleManager>();
            string[] arguments = null;

            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(mockedBattleManager.Object, arguments));
        }

        [Test]
        public void ThrowArgumentNullExpeption_WhenTheParamsArgumentIsInavlid()
        {
            var addCommand = new AddCommand();
            var mockedBattleManager = new Mock<IBattleManager>();
            string[] arguments = new string[] { "10" };

            Assert.Throws<ArgumentException>(() => addCommand.ProcessCommand(mockedBattleManager.Object, arguments));
        }

        [Test]
        public void ReturnNoExpection_WhenTheCommandIsParsedSuccessfully()
        {
            var addCommand = new AddCommand();
            var mockedBattleManager = new Mock<IBattleManager>();
            string[] arguments = new string[] { "10", "AncientBehemoth(1)" };

            Assert.DoesNotThrow(() => addCommand.ProcessCommand(mockedBattleManager.Object, arguments));
        }
    }
}