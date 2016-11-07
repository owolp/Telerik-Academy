namespace Cars.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Data;

    public static class XmlSearcher
    {
        private static CarsDbContext db;

        public static void Search()
        {
            db = new CarsDbContext();

            var xmlQueries = XElement.Load(@"..\..\XmlFiles\queries.xml").Elements();

            foreach (var xmlQuery in xmlQueries)
            {
                var fileName = xmlQuery.Attribute("OutputFileName").Value;
                var result = new XElement(fileName);
            }
        }
    }
}
