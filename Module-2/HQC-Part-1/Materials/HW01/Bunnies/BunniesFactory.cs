namespace High.Quality.Code.BadExample
{
    using System.Collections.Generic;
    using System.IO;
    using CodeFormatting;

    /// <summary>
    /// class Bunnies is created to build a lot of Bunny objects
    /// </summary>
    public class BunniesFactory
    {
        /// <summary>
        /// Main method fot the project
        /// </summary>
        public static void Main()
        {
            var bunnies = new List<Bunny>
            { 
                new Bunny { Name = "Leonid", Age = 1, FurType = FurType.NotFluffy },
                new Bunny { Age = 2, Name = "Rasputin", FurType = FurType.ALittleFluffy },
                new Bunny { FurType = FurType.ALittleFluffy, Name = "Tiberii", Age = 3 },
                new Bunny { Name = "Neron", FurType = FurType.ALittleFluffy, Age = 1 },
                new Bunny { Name = "Klavdii", Age = 3, FurType = FurType.Fluffy },
                new Bunny { Name = "Vespasian", Age = 3, FurType = FurType.Fluffy },
                new Bunny { Name = "Domician", Age = 4, FurType = FurType.FluffyToTheLimit },
                new Bunny { Name = "Tit", Age = 2, FurType = FurType.FluffyToTheLimit }
            };

            var consoleWriter = new ConsoleWriter();

            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }

            var bunniesFilePath = @"..\..\bunnies.txt";

            var fileStream = File.Create(bunniesFilePath);

            fileStream.Close();

            using (var streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }
    }
}