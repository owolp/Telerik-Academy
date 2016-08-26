namespace TestStudentClass
{
    using System;
    using System.Collections.Generic;
    using StudentClass.Enumerators;
    using StudentClass.Models;

    public class TestStudentClass
    {
        public static void Main()
        {
            var students = new List<Student>();

            students.Add(
                new Student(
                    "Ivan", 
                    "Ivanov", 
                    "Ivanov", 
                    10101010,
                    "Sofia 1000", 
                    "+359088888888", 
                    "iivanov@iivanov.bg", 
                    1, 
                    Specialty.AgriculturalProduction, 
                    University.CapellaUniversity, 
                    Faculty.FacultyOfArchitectureAndHistoryOfArt));

            students.Add(
                new Student(
                    "Georgi", 
                    "Georgiev", 
                    "Georgiev", 
                    20202020,
                    "Bourgas 1000", 
                    "+35907777777",
                    "ggoeorgiev@ggoeorgiev.bg", 
                    2, 
                    Specialty.AnimalBreeding, 
                    University.ColoradoTechnicalUniversity, 
                    Faculty.FacultyOfAsianAndMiddleEasternStudies));

            students.Add(
                new Student(
                    "Ivan",
                    "Ivanov",
                    "Ivanov",
                    10101010,
                    "Sofia 1000",
                    "+359088888888",
                    "iivanov@iivanov.bg",
                    1,
                    Specialty.AgriculturalProduction,
                    University.CapellaUniversity,
                    Faculty.FacultyOfArchitectureAndHistoryOfArt));

            Console.WriteLine(new string('=', 50));

            // Problem 1. Student class ToString()
            Console.WriteLine("Problem 1. Student class ToString()\n");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('-', 20));

            // Problem 1. Student class Equals()
            Console.WriteLine("Problem 1. Student class Equals()\n");
            Console.WriteLine("FirstStudent.Equals(SecondStudent) = {0}", students[0].Equals(students[1]));
            Console.WriteLine("FirstStudent.Equals(ThirdStudent) = {0}\n", students[0].Equals(students[2]));

            Console.WriteLine(new string('-', 20));

            // Problem 1. Student class GetHashCode()
            Console.WriteLine("Problem 1. Student class GetHashCode()\n");
            Console.WriteLine("HashCode First Student: {0}", students[0].GetHashCode());
            Console.WriteLine("HashCode Second Student: {0}\n", students[1].GetHashCode());

            Console.WriteLine(new string('-', 20));

            // Problem 1. Student class == and !=
            Console.WriteLine("Problem 1. Student class == and !=\n");
            Console.WriteLine("FirstStudent == SecondStudent: {0}", students[0] == students[1]);
            Console.WriteLine("FirstStudent != SecondStudent: {0}\n", students[0] != students[1]);

            Console.WriteLine(new string('=', 50));

            // Problem 2. ICloneable
            Console.WriteLine("Problem 2. ICloneable\n");
            var firstStudentCloned = students[0].Clone();
            Console.WriteLine(firstStudentCloned);

            Console.WriteLine(new string('=', 50));

            // Problem 2. IComparable
            Console.WriteLine("Problem 3. IComparable\n");
            Console.WriteLine("If -1 the first student is before the second student.");
            Console.WriteLine("If 1 the first student is after the second student.");
            Console.WriteLine("If null(0) the first student is equal to the second student.\n");
            Console.WriteLine("FirstStudent.CompareTo(SecondStudent): {0}", students[0].CompareTo(students[1]));
            Console.WriteLine("FirstStudent.CompareTo(ThirdStudent)\n", students[0].CompareTo(students[2]));
        }
    }
}
