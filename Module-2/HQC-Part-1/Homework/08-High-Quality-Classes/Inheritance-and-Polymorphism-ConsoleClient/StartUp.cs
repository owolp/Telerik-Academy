namespace Inheritance_and_Polymorphism_ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using InheritanceAndPolymorphism.Models;

    public class StartUp
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse.ToString());

            localCourse.LaboratoryName = "Enterprise";
            Console.WriteLine(localCourse.ToString());

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse.ToString());

            localCourse.TeacherName = "SvetlinNakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse.ToString());

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "High-Quality-Code",
                new List<string>() { "Thomas", "Ani", "Steve" },
                "MarioPeshev");
            Console.WriteLine(offsiteCourse.ToString());
        }
    }
}
