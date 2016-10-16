﻿namespace TraverseGivenDirectory
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class TraverseGivenDirectory
    {
        private const string DirectoryXml = "../../directory.xml";
        private const string RootDirectory = "../../../";

        private static void Main()
        {
            GenerateXmlDirectoryTree();
        }

        private static void GenerateXmlDirectoryTree()
        {
            var fileName = DirectoryXml;
            var encoding = Encoding.GetEncoding("utf-8");
            var rootDirectory = new DirectoryInfo(RootDirectory);
            using (var writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;

                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                TraverseRootDirectoryRecursively(writer, rootDirectory);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void TraverseRootDirectoryRecursively(XmlTextWriter writer, DirectoryInfo rootDirectory)
        {
            if (!rootDirectory.GetFiles().Any() && !rootDirectory.GetDirectories().Any())
            {
                return;
            }

            writer.WriteStartElement("dir");
            writer.WriteStartAttribute("name", rootDirectory.Name);

            foreach (var file in rootDirectory.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteStartAttribute("name", file.Name);
                writer.WriteEndElement();
            }

            foreach (var directory in rootDirectory.GetDirectories())
            {
                TraverseRootDirectoryRecursively(writer, directory);
            }

            writer.WriteEndElement();
        }
    }
}
