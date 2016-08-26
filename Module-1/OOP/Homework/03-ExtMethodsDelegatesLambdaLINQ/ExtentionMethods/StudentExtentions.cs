namespace ExtentionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Student;

    public static class StudentExtentions
    {
        public static List<Student> SortByGroup(this List<Student> students, uint groupNumber)
        {
            if (students.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            return students.Where(c => c.GroupNumber == groupNumber).OrderBy(c => c.FirstName).ToList();
        }

        public static List<Student> ExtactByNumberOfMarks(this List<Student> students, uint numberOfMarks)
        {
            if (students.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            return students.Where(s => s.Marks.Count() == numberOfMarks).ToList();
        }

        public static List<Student> ExtractMarksByYear(this List<Student> students, int year)
        {
            if (students.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            string yearAsString = year.ToString().Substring(Math.Max(0, year.ToString().Length - 2));

            return students.Where(s => s.FacultyNumber.ToString().EndsWith(yearAsString)).ToList();
        }

        public static List<uint> GroupByGroupNumber(this List<Student> students)
        {
            var result = new List<uint>();

            if (students.Count() == 0)
            {
                throw new ArgumentException("The collection can not be empty.");
            }

            var groups = students.GroupBy(s => s.GroupNumber).ToList();

            foreach (var item in groups)
            {
                result.Add(item.Key);
            }

            return result;
        }
    }
}