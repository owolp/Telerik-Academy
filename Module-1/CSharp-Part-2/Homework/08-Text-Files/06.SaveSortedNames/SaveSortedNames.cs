namespace SaveSortedNames
{
    using System;
    using System.IO;

    class SaveSortedNames
    {
        static void Main()
        {
            var inputFile = "../../files/input.txt";
            var outputFile = "../../files/output.txt";

            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            var content = File.ReadAllLines(inputFile);
            Array.Sort(content);

            File.WriteAllLines(outputFile, content);
        }
    }
}