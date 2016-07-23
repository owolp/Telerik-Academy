namespace SchoolAssembly
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class School
    {
        private string name;
        private IList<Course> courses;
        private IList<Student> students;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, Constants.SchoolNameCannotBeNull);

                this.name = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public IList<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
        }

        public void AddStudent(Student student)
        {
            Validator.ValidateNull(student, Constants.StudentNameCannotBeNull);

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.ValidateNull(student, Constants.StudentNameCannotBeNull);

            if (!this.students.Contains(student))
            {
                throw new InvalidOperationException("The student cannot be removed from the school, as he/she is not attending it!");
            }

            this.students.Remove(student);
        }

        public void AddCourse(Course course)
        {
            Validator.ValidateNull(course, Constants.CourseNameCannotBeNull);

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            Validator.ValidateNull(course, Constants.CourseNameCannotBeNull);

            if (!this.courses.Contains(course))
            {
                throw new InvalidOperationException("The course cannot be removed from the school, as it is not added to it!");
            }

            this.courses.Remove(course);
        }
    }
}
