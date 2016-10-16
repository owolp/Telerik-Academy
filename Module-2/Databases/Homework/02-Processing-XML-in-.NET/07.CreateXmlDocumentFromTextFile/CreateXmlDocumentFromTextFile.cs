namespace CreateXmlDocumentFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class CreateXmlDocumentFromTextFile
    {
        private const string PhoneBookTxtFile = "../../phonebook.txt";
        private const string PhoneBookXmlFile = "../../phonebook.xml";

        private static void Main()
        {
            var fileData = GetFileData(PhoneBookTxtFile);
            var persons = ExtractSubscribers(fileData);
            var phonebookXml = GeneratePhonebookXmlFile(persons);
            phonebookXml.Save(PhoneBookXmlFile);
        }

        private static XElement GeneratePhonebookXmlFile(IEnumerable<IPerson> persons)
        {
            var phonebookXml = new XElement(XName.Get("phonebook"));
            foreach (var person in persons)
            {
                var personXml = new XElement(
                    "person",
                    new XElement("name", person.Name),
                    new XElement("city", person.Address),
                    new XElement("phone", person.PhoneNumber));

                phonebookXml.Add(personXml);
            }

            return phonebookXml;
        }

        private static IEnumerable<IPerson> ExtractSubscribers(string fileData)
        {
            var persons = new List<IPerson>();

            var splittedFileData = fileData.Split('\n');
            foreach (var line in splittedFileData)
            {
                var person = line
                    .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .ToArray();

                persons.Add(new Person
                {
                    Name = person[0],
                    Address = person[1],
                    PhoneNumber = person[2]
                });
            }

            return persons;
        }

        private static string GetFileData(string fullPath)
        {
            string data;
            using (var reader = new StreamReader(fullPath))
            {
                data = reader.ReadToEnd();
            }

            return data;
        }
    }
}
