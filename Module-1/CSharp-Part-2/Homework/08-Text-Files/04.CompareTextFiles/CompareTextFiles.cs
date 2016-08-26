namespace CompareTextFiles
{
    using System;
    using System.IO;

    class CompareTextFiles
    {
        static void Main()
        {
            var firstPath = "../../files/DecimalToBinary.cs";
            var secondPath = "../../files/EnterNumbers.cs";

            int equalCount = 0;
            int notEqualCount = 0;

            using (var firstFile = new StreamReader(firstPath))
            {
                using (var secondFile = new StreamReader(secondPath))
                {
                    var lineFirstFile = firstFile.ReadLine();
                    var lineSecondFile = secondFile.ReadLine();

                    while (lineSecondFile != null)
                    {
                        if (lineFirstFile == lineSecondFile)
                        {
                            equalCount++;
                        }
                        else
                        {
                            notEqualCount++;
                        }

                        lineFirstFile = firstFile.ReadLine();
                        lineSecondFile = secondFile.ReadLine();
                    }
                }
            }

            Console.WriteLine("Equal: {0}", equalCount);
            Console.WriteLine("Not equal: {0}", notEqualCount);
        }
    }
}