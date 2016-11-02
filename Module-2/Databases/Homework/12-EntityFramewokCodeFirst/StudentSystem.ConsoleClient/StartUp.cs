namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models.Models;

    public class StartUp
    {
        public static void Main()
        {
            var db = new StudentSystemDbContext();

            var course = new Course
            {
                Name = "Databases",
                Description = "TelerikAcademy"
            };

            db.Courses.Add(course);

            var student = new Student
            {
                FirstName = "John",
                LastName = "Smith",
                FacultyNumber = "1234567890"
            };

            db.Students.Add(student);

            db.SaveChanges();

            var firstCourse = db.Courses.FirstOrDefault();
            Console.WriteLine($"Course name: {firstCourse.Name}, Description: {firstCourse.Description}");

            var firstStudent = db.Students.FirstOrDefault();
            Console.WriteLine($"Students' first name: {firstStudent.FirstName}, last name: {firstStudent.LastName}, FN: {firstStudent.FacultyNumber}");
        }
    }
}
