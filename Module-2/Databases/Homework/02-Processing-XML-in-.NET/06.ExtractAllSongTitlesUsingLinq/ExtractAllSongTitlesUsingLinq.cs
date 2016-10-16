namespace ExtractAllSongTitlesUsingLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractAllSongTitlesUsingLinq
    {
        private const string DocumentLocation = "../../catalog.xml";

        public static void Main()
        {
            Console.WriteLine("Song titles in the catalog:");

            XDocument xmlDoc = XDocument.Load(DocumentLocation);
            var songs =
                from song in xmlDoc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value
                };

            foreach (var song in songs)
            {
                var songTitle = song.Title;
                Console.WriteLine(songTitle);
            }
        }
    }
}
