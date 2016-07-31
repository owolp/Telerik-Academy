namespace School.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Validator
    {
        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateCollectionContainsStudent(ICollection<Student> collection, Student student, string message = null)
        {
            if (collection.Any(st => st.Id == student.Id))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateCollectionDoesNotContainsStudent(ICollection<Student> collection, Student student, string message = null)
        {
            if (!collection.Any(st => st.Id == student.Id))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateCollectionContainsCourse(ICollection<Course> courses, Course course, string message = null)
        {
            if (courses.Any(c => c.Name == c.Name))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateCollectionDoesNotContainCourse(ICollection<Course> courses, Course course, string message = null)
        {
            if (courses.Any(c => c.Name != c.Name))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
