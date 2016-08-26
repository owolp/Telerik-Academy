//10. Employee Data
//Description
//A marketing company wants to keep record of its employees.Each record would have the following characteristics:
//    First name
//    Last name
//    Age(0...100)
//    Gender(m or f)
//    Personal ID number(e.g. 8306112507)
//    Unique employee number(27560000…27569999)
//Declare the variables needed to keep the information for a single employee using appropriate primitive data types.Use descriptive names.Print the data at the console.

using System;

namespace EmployeeData
{
    class EmployeeData
    {
        static void Main()
        {
            var firstName = "John";
            var lastName = "Smith";
            byte age = 30;
            var gender = "M";
            long idNumber = 8306112507;
            uint employeeNumber = 27560000;

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", firstName, lastName, age, gender, idNumber, employeeNumber);
        }
    }
}