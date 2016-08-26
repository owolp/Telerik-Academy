namespace TestSchool
{
    using System.Collections.Generic;
    using School;
    using School.Enumerators;
    using School.Models;

    public class TestSchool
    {
        public static void Main()
        {
            var newSchool = new School("Telerik Academy");

            var firstStudent = new Student("Ivan", "Ivanov", 1);
            var secondStudent = new Student("Petar", "Petrov", 2);
            var thirdStudent = new Student("Georgi", "Georgiev", 3);

            var students = new List<Student>();
            students.Add(firstStudent);
            students.Add(secondStudent);
            students.Add(thirdStudent);

            var firstTeacher = new Teacher("Nikolay", "Nikolov", new Discipline(DisciplineSubject.Architecture, 10, 20));
            var secondTeacher = new Teacher("Aleksandar", "Aleksandrov", new Discipline(DisciplineSubject.Biology, 20, 30));
            var thirdTeacher = new Teacher("Martin", "Martinov", new Discipline(DisciplineSubject.Business, 30, 40));

            var teachers = new List<Teacher>();
            teachers.Add(firstTeacher);
            teachers.Add(secondTeacher);
            teachers.Add(thirdTeacher);

            newSchool.AddStudent(firstStudent);
            newSchool.AddStudent(secondStudent);
            newSchool.AddStudent(thirdStudent);
    
            newSchool.AddTeacher(firstTeacher);
            newSchool.AddTeacher(secondTeacher);
            newSchool.AddTeacher(thirdTeacher);
        }
    }
}
