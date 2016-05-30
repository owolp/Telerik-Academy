namespace ConcatenateTextFiles
{
    using System.IO;

    class ConcatenateTextFiles
    {
        static void Main()
        {
            var firstPath = "../../files/DecimalToBinary.cs";
            var secondPath = "../../files/EnterNumbers.cs";
            var concatenatedFileName = "../../files/concat.cs";

            if (File.Exists(concatenatedFileName))
            {
                File.Delete(concatenatedFileName);
            }

            //FileStream fs = File.Create(concatenatedFileName);
            //fs.Close();

            using (var concat = new StreamWriter(concatenatedFileName, true))
            {
                using (var file = new StreamReader(firstPath))
                {
                    concat.WriteLine(file.ReadToEnd());
                }

                using (var file = new StreamReader(secondPath))
                {
                    concat.WriteLine(file.ReadToEnd());
                }
            }
        }
    }
}