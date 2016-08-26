namespace LineNumbers
{
    using System.IO;

    class LineNumbers
    {
        static void Main()
        {
            var inputFile = "../../files/DecimalToBinary.cs";
            var outputFile = "../../files/output.cs";

            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            using (var output = new StreamWriter(outputFile))
            {
                using (var input = new StreamReader(inputFile))
                {
                    var line = input.ReadLine();
                    var lineIndex = 1;

                    while (line != null)
                    {
                        output.Write(lineIndex + " ");
                        output.WriteLine(line);

                        line = input.ReadLine();
                        lineIndex++;
                    }
                }
            }
        }
    }
}