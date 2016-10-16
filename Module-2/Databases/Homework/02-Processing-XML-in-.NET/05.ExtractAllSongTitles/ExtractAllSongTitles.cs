namespace ExtractAllSongTitles
{
    using System;
    using System.Xml;

    public class Program
    {
        private const string DocumentLocation = "../../catalog.xml";

        public static void Main()
        {
            Console.WriteLine("Song titles in the catalog:");

            using (XmlReader reader = XmlReader.Create(DocumentLocation))
            {
                while (reader.Read())
                {
                    var isXmlNodeTypeElement = reader.NodeType == XmlNodeType.Element;
                    var isReaderNameTitle = reader.Name == "title";
                    if (isXmlNodeTypeElement && isReaderNameTitle)
                    {
                        var elementString = reader.ReadElementString();
                        Console.WriteLine(elementString);
                    }
                }
            }
        }
    }
}
