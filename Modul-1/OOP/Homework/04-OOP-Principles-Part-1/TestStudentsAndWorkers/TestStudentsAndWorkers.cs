namespace TestStudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StudentsAndWorkers.AbstractModels;
    using StudentsAndWorkers.Models;

    public class TestStudentsAndWorkers
    {
        public static void Main()
        {
            var workers = LoadWorkers();
            var worker = new Worker("Susan", "Cummings", 65, 20);
            var sortedWorkers = worker.Order(workers);

            Console.WriteLine("Not sorted workers list");
            foreach (var w in workers)
            {
                Console.WriteLine("\t" + w);
            }

            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Sorted workers list by \"Money per Hour\"");
            foreach (var w in sortedWorkers)
            {
                Console.WriteLine("\t" + w);
            }

            Console.WriteLine(new string('=', 50));

            var students = LoadStudents();
            var student = new Student("Susan", "Cummings", 65);
            var sortedStudents = student.Order(students);

            Console.WriteLine("Not sorted student list");
            foreach (var s in students)
            {
                Console.WriteLine("\t" + s);
            }

            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Sorted students list by \"Grade\"");
            foreach (var s in sortedStudents)
            {
                Console.WriteLine("\t" + s);
            }

            Console.WriteLine(new string('=', 50));

            var mergedList = new List<Human>();
            mergedList.AddRange(workers);
            mergedList.AddRange(students);
            var sortedMergedList = mergedList.OrderBy(h => h.FirstName).ToList();

            Console.WriteLine("Merged students and workers not sorted");

            foreach (var h in mergedList)
            {
                Console.WriteLine("\t" + h.FirstName);
            }

            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Merged students and workers list sorted by \"First Name\"");

            foreach (var h in sortedMergedList)
            {
                Console.WriteLine("\t" + h.FirstName);
            }

            Console.WriteLine(new string('=', 50));
        }

        public static List<Worker> LoadWorkers()
        {
            var workers = new List<Worker>();

            workers.Add(new Worker("Susan", "Cummings", 65, 20));
            workers.Add(new Worker("Kylie", "Zamora", 78, 40));
            workers.Add(new Worker("Daria", "James", 77, 30));
            workers.Add(new Worker("Grant", "Mall", 54, 15));
            workers.Add(new Worker("Savannah", "Mullins", 70, 35));
            workers.Add(new Worker("Aimee", "Taylor", 97, 40));
            workers.Add(new Worker("Amery", "Weber", 67, 30));
            workers.Add(new Worker("Rhea", "Baird", 92, 40));
            workers.Add(new Worker("Tanisha", "Walton", 59, 20));
            workers.Add(new Worker("Clare", "Smith", 71, 30));

            return workers;
        }

        public static List<Student> LoadStudents()
        {
            var students = new List<Student>();

            students.Add(new Student("Susan", "Cummings", 65));
            students.Add(new Student("Kylie", "Zamora", 78));
            students.Add(new Student("Daria", "James", 77));
            students.Add(new Student("Grant", "Mall", 54));
            students.Add(new Student("Savannah", "Mullins", 70));
            students.Add(new Student("Aimee", "Taylor", 97));
            students.Add(new Student("Amery", "Weber", 67));
            students.Add(new Student("Rhea", "Baird", 92));
            students.Add(new Student("Tanisha", "Walton", 59));
            students.Add(new Student("Clare", "Smith", 71));

            return students;
        }
    }
}