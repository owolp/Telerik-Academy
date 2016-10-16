namespace DeleteAlbums
{
    using System.Xml;

    public class DeleteAlbums
    {
        private const string DocumentLocation = "../../catalog.xml";

        public static void Main()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(DocumentLocation);
            var rootNode = xmlDocument.DocumentElement;
            var albums = rootNode.SelectNodes("album");

            foreach (XmlElement album in albums)
            {
                var price = double.Parse(album["price"].InnerText);
                if (price > 20)
                {
                    rootNode.RemoveChild(album);
                }
            }

            xmlDocument.Save("../../new-catalog.xml");
        }
    }
}
