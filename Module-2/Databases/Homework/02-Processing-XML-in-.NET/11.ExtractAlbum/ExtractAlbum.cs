namespace ExtractAlbum
{
    using System;
    using System.Xml;

    public class ExtractAlbum
    {
        private const string DocumentLocation = "../../catalog.xml";

        public static void Main()
        {
            var xPathQuery = "/catalog/album[year]";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(DocumentLocation);

            var albumsList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode albumNode in albumsList)
            {
                var year = int.Parse(albumNode.SelectSingleNode("year").InnerText);
                if (year >= 2000 && year < 2005)
                {
                    var albumName = albumNode.SelectSingleNode("name").InnerText;
                    var albumPrice = albumNode.SelectSingleNode("price").InnerText;
                    Console.WriteLine("{0}: {1}$", albumName, albumPrice);
                }
            }
        }
    }
}
