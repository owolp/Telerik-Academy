namespace ExtractUsingDom
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    public class ExtractUsingDom
    {
        private const string documentLocation = "../../catalog.xml";

        public static void Main()
        {
            var rootNode = LoadDocument();
            var artists = GetAllArtists(rootNode);
            var albums = ExtractAlbumsForArtist(rootNode);
            var output = Output(albums);

            Console.Write(output);
        }

        private static XmlElement LoadDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(documentLocation);
            XmlElement rootNode = doc.DocumentElement;

            return rootNode;
        }

        private static StringBuilder Output(IDictionary<string, int> albums)
        {
            StringBuilder result = new StringBuilder();

            foreach (var album in albums)
            {
                var output = $"{album.Key} - {album.Value}";
                result.AppendLine(output);
            }

            return result;
        }

        private static IDictionary<string, int> ExtractAlbumsForArtist(XmlElement rootNode)
        {
            var result = new Dictionary<string, int>();

            var albums = rootNode.GetElementsByTagName("cat:album");
            foreach (XmlNode album in albums)
            {
                var artist = album["cat:artist"].InnerText;
                if (!result.ContainsKey(artist))
                {
                    result[artist] = 0;
                }

                result[artist]++;
            }

            return result;
        }

        private static IEnumerable<string> GetAllArtists(XmlElement rootNode)
        {
            var result = new HashSet<string>();

            var albums = rootNode.GetElementsByTagName("cat:album");
            foreach (XmlNode album in albums)
            {
                result.Add(album["cat:artist"].InnerText);
            }

            return result;
        }
    }
}
