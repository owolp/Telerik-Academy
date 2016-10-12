using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Moq;
using SchoolSystem.Framework.Commands.Contracts;
using SchoolSystem.Framework.Engines;
using SchoolSystem.Framework.Engines.Contracts;
using SchoolSystem.Framework.IO.Contracts;

namespace SchoolSystem.Framework.Tests.Engines
{
    [TestFixture]
    public class SchoolSystemEngineTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenUserInterfaceParamaterIsNotValid()
        {
            IUserInterfaceProvider userInterface = null;
            var commandProvider = new Mock<ICommandProvider>();

            Assert.That(
                () => new SchoolSystemEngine(userInterface, commandProvider.Object),
                Throws.ArgumentNullException.With.Message.Contains("userInterface"));
        }

        [Test]
        public void Constructor_ShouldThrow_WhenCommandProviderParamaterIsNotValid()
        {
            var userInterface = new Mock<IUserInterfaceProvider>();
            ICommandProvider commandProvider = null;

            Assert.That(
                () => new SchoolSystemEngine(userInterface.Object, commandProvider),
                Throws.ArgumentNullException.With.Message.Contains("commandProvider"));
        }

        [Test]
        public void Start_ShouldInvokeUserInterfaceReadLineOnce_IfTheFirstCommandIsEnd()
        {
            var commandsString = "End";
            var stringReader = new StringReader(commandsString);

            var userInterface = new Mock<IUserInterfaceProvider>();
            userInterface.Setup(ui => ui.ReadLine()).Returns(stringReader.ReadLine());

            var commandProvider = new Mock<ICommandProvider>();

            var engine = new SchoolSystemEngine(userInterface.Object, commandProvider.Object);
            engine.Start();

            userInterface.Verify(ui => ui.ReadLine(), Times.Once());
        }

        [Test]
        public void Start_ShouldInvokeUserInterfaceWriteLineWithCorrectMessage_WhenInputIsAnEmptyLine()
        {
            var startIndex = 0;
            var commandsStrings = new List<string>()
            {
                "",
                "End"
            };

            var userInterface = new Mock<IUserInterfaceProvider>();
            userInterface.Setup(ui => ui.ReadLine()).Returns(() =>
               {
                   return commandsStrings[startIndex++];
               });

            var commandProvider = new Mock<ICommandProvider>();

            var engine = new SchoolSystemEngine(userInterface.Object, commandProvider.Object);
            engine.Start();

            userInterface.Verify(ui => ui.WriteLine("The passed command is not found!"), Times.Once());
        }

        [Test]
        public void Start_ShouldInvokeUserInterfaceWriteLineWithCorrectMessage_WhenCommandIsNotFound()
        {
            var startIndex = 0;
            var commandsStrings = new List<string>()
            {
                "NotExistingCommand 1 2 3",
                "End"
            };

            var userInterface = new Mock<IUserInterfaceProvider>();
            userInterface.Setup(ui => ui.ReadLine()).Returns(() =>
            {
                return commandsStrings[startIndex++];
            });

            var commandProvider = new Mock<ICommandProvider>();
            commandProvider.Setup(cp => cp.FindCommandExecutorWithName(It.IsAny<string>())).Returns(() => null);

            var engine = new SchoolSystemEngine(userInterface.Object, commandProvider.Object);
            engine.Start();

            userInterface.Verify(ui => ui.WriteLine("The passed command is not found!"), Times.Once());
        }

        [Test]
        public void Start_ShouldInvokeTheCommand_WithCorrectParameters()
        {
            var startIndex = 0;
            var commandsStrings = new List<string>()
            {
                "NotExistingCommand 1 2 3",
                "End"
            };

            var commandParameters = new List<string>() { "1", "2", "3" };

            var userInterface = new Mock<IUserInterfaceProvider>();
            userInterface.Setup(ui => ui.ReadLine()).Returns(() =>
            {
                return commandsStrings[startIndex++];
            });

            var mockCommand = new Mock<ICommand>();
            var commandProvider = new Mock<ICommandProvider>();
            commandProvider.Setup(cp => cp.FindCommandExecutorWithName(It.IsAny<string>())).Returns(mockCommand.Object);

            var engine = new SchoolSystemEngine(userInterface.Object, commandProvider.Object);
            engine.Start();

            mockCommand.Verify(command => command.Execute(commandParameters, It.IsAny<ISchoolSystemEngine>()), Times.Once());
        }

        [Test]
        public void Start_ShouldInvokeUserInterfaceWriteLine_WithCorrectMessageWhenCommandHasExecutedCorrectly()
        {
            var expectedMessage = "expected message";

            var startIndex = 0;
            var commandsStrings = new List<string>()
            {
                "CreateTeacher 1 2 3",
                "End"
            };

            var userInterface = new Mock<IUserInterfaceProvider>();
            userInterface.Setup(ui => ui.ReadLine()).Returns(() =>
            {
                return commandsStrings[startIndex++];
            });

            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(command => command.Execute(It.IsAny<IList<string>>(), It.IsAny<ISchoolSystemEngine>()))
                .Returns(expectedMessage);

            var commandProvider = new Mock<ICommandProvider>();
            commandProvider.Setup(cp => cp.FindCommandExecutorWithName(It.IsAny<string>())).Returns(mockCommand.Object);

            var engine = new SchoolSystemEngine(userInterface.Object, commandProvider.Object);
            engine.Start();

            userInterface.Verify(ui => ui.WriteLine(expectedMessage), Times.Once());
        }

        [TestCase("CreateStudent FirstName LastName 5", "CreateStudent")]
        [TestCase("CreateTeacher FirstName LastName 5", "CreateTeacher")]
        [TestCase("RemoveStudent 5", "RemoveStudent")]
        [TestCase("RemoveTeacher 5", "RemoveTeacher")]
        [TestCase("TeacherAddMark 1 2 5", "TeacherAddMark")]
        [TestCase("StudentListMarks 5", "StudentListMarks")]

        public void Start_ShouldInvokeCommandProviderFindCommandWithName_WithCorrectParameter(string command, string commandName)
        {
            var startIndex = 0;
            var commandsStrings = new List<string>()
            {
                command,
                "End"
            };

            var userInterface = new Mock<IUserInterfaceProvider>();
            userInterface.Setup(ui => ui.ReadLine()).Returns(() =>
            {
                return commandsStrings[startIndex++];
            });

            var commandProvider = new Mock<ICommandProvider>();
            commandProvider.Setup(cp => cp.FindCommandExecutorWithName(It.IsAny<string>())).Returns(new Mock<ICommand>().Object);

            var engine = new SchoolSystemEngine(userInterface.Object, commandProvider.Object);
            engine.Start();

            commandProvider.Verify(cp => cp.FindCommandExecutorWithName(commandName), Times.Once());
        }
    }
}
