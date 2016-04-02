//02. Company Info
//Description
//    A company has name, address, phone number, fax number, web site and manager.The manager has first name, last name, age and a phone number.
//    Write a program that reads the information about a company and its manager and prints it back on the console.
//Input
//    You will each piece of information about the company on a separate line, in the same order as in the example
//        Company name
//        Company address
//        Phone number
//        Fax number
//        Web site
//        Manager first name
//        Manager last name
//        Manager age
//        Manager phone
//Output
//    Print the information the same way as shown in the sample test.Make sure that you print "(no fax)" if an empty line is passed as fax number.
//Constraints
//    The input will always be in the described format
//    Only the fax number field can be empty, all other fields will have be least one symbol
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace CompanyInfo
{
    class CompanyInfo
    {
        static void Main()
        {
            var companyName = Console.ReadLine();
            var companyAddress = Console.ReadLine();
            var companyPhoneNumber = Console.ReadLine();
            var companyFaxNumber = Console.ReadLine();
            var companyWebSite = Console.ReadLine();
            var managerFirstName = Console.ReadLine();
            var managerLastName = Console.ReadLine();
            byte managerAge = byte.Parse(Console.ReadLine());
            var managerPhoneNumber = Console.ReadLine();

            if (companyFaxNumber == "")
            {
                companyFaxNumber = "(no fax)";
            }

            Console.WriteLine("{0}\n" +
                               "Address: {1}\n" +
                               "Tel. {2}\n" +
                               "Fax: {3}\n" +
                               "Web site: {4}\n" +
                               "Manager: {5} {6} (age: {7}, tel. {8})",
                               companyName, companyAddress, companyPhoneNumber, companyFaxNumber, companyWebSite, managerFirstName, managerLastName, managerAge, managerPhoneNumber);
        }
    }
}