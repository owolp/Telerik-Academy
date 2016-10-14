namespace ExtractUsingXPath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    public class ExtractUsingXPath
    {
        private const string documentLocation = "../../catalog.xml";

        public static void Main()
        {
            var rootNode = LoadDocument();
            string xPathQuery = "/catalog/album";
            var albumsList = rootNode.SelectNodes(xPathQuery);
            var artistList = ExtractArtistsFromCatalog(albumsList);
            var output = Output(artistList);

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

        private static Dictionary<string, int> ExtractArtistsFromCatalog(IEnumerable albumsList)
        {
            var artistsList = new Dictionary<string, int>();
            foreach (XmlNode album in albumsList)
            {
                var artistName = album.SelectSingleNode("artist").InnerText;
                if (!artistsList.ContainsKey(artistName))
                {
                    artistsList[artistName] = 0;
                }

                artistsList[artistName]++;
            }

            return artistsList;
        }
    }
}
