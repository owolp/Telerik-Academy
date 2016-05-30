namespace OddLines
{
    using System;
    using System.IO;

    class OddLines
    {
        static void Main()
        {
            var filePath = "../../files/EnterNumbers.cs";

            using (var file = new StreamReader(filePath))
            {
                var line = file.ReadLine();
                var lineNumber = 0;

                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    line = file.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}