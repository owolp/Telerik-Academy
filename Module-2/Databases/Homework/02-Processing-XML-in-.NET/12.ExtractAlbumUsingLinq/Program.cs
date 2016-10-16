namespace ExtractAlbumUsingLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class Program
    {
        private const string DocumentLocation = "../../catalog.xml";

        public static void Main()
        {
            var xmlDoc = XDocument.Load(DocumentLocation);
            var albums =
                from album in xmlDoc.Descendants("album")
                where album.Element("year").Value.Contains("200")
                select new
                {
                    Name = album.Element("name").Value,
                    Price = album.Element("price").Value
                };

            foreach (var album in albums)
            {
                Console.WriteLine("{0}: {1}", album.Name, album.Price);
            }
        }
    }
}
