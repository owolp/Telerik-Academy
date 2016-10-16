namespace XlsXslt
{
    using System.Xml.Xsl;

    public class XlsXslt
    {
        public static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../catalog.xsl");
            xslt.Transform("../../catalog.xml", "../../catalog.html");
        }
    }
}
