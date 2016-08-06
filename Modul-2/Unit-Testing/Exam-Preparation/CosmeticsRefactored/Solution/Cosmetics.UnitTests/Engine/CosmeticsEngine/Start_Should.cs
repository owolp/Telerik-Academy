namespace Cosmetics.UnitTests.Engine.CosmeticsEngine
{
    using System;
    using System.Collections.Generic;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Cosmetics.UnitTests.Engine.CosmeticsEngine.Mocks;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class Start_Should
    {
        // Start should read, parse and execute "CreateCategory" command, when the passed input string is in the format that represents a CreateCategory command, which should result in adding the new Category in the list of categories.
        [Test]
        public void ReadParseAndExecuteCreateCategoryCommand_WhenThePassedInputStringIsInTheCorrectFormat()
        {
            // Arrange
            /*
                Задаваме име на категорията с което ще тестваме 
            */
            var categoryName = "categoryName";

            /*
                За да може да създадем нов обект от тип CosmeticsEngine за конструктора са нужни:
                    ICosmeticsFactory factory,
                    IShoppingCart shoppingCart,
                    ICommandParser commandParser
                За да нямаме нужда от тях създаваме Mock обекти за всеки един от трите
            */
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            /*
                В заданието се иска да проверим дали CosmeticsEngine обект и неговия Start()
                ще върнат правилна категория и команда.
                За да нямаме нужда от тях създаваме Mock обекти за двата обекта
            */
            var mockedCategory = new Mock<ICategory>();
            var mockedCommand = new Mock<ICommand>();

            /*
                Задаваме параметри на мокнатата команда.
                SetupGet задава стойност при Get на параметър Name.
                Returns задава при извикване на Get на Name какво да се върне.
                В случая се връща New List<string>() с categoryName в него, както се изисква от Command.Parse()
            */
            mockedCommand.SetupGet(c => c.Name).Returns("CreateCategory");
            mockedCommand.SetupGet(c => c.Parameters).Returns(new List<string>() { categoryName });

            /*
                След като сме създали мокната команда подаваме командата на ConsoleCommandParser : ICommandParser
                Задаваме какво да връща метода ReadCommands() в случай на негово извикване
            */
            mockedCommandParser.Setup(c => c.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedCategory.SetupGet(c => c.Name).Returns(categoryName);

            mockedFactory.Setup(f => f.CreateCategory(categoryName)).Returns(mockedCategory.Object);

            var mockedCosmeticsEngine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // Act
            mockedCosmeticsEngine.Start();

            // Assert
            Assert.IsTrue(mockedCosmeticsEngine.Categories.ContainsKey(categoryName));
            Assert.AreEqual(mockedCategory.Object, mockedCosmeticsEngine.Categories[categoryName]);
        }
    }
}