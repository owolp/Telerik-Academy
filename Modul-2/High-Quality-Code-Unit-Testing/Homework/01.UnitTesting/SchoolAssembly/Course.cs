namespace SchoolAssembly
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class Course
    {
        private string name;
        private IList<Student> students;

        public Course(string name)
        {
            this.Name = name;
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
                Validator.CheckIfStringIsNullOrEmpty(value, Constants.CourseNameCannotBeNull);

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

        public void AddStudent(Student student)
        {
            Validator.ValidateNull(student, Constants.StudentNameCannotBeNull);

            Validator.ValidateIntRange(
                this.students.Count,
                Constants.MinStudentsInCourse,
                Constants.MaxStudentsInCourse,
                string.Format(Constants.NumberMustBeBetweenMinAndMax, "Students count in course", Constants.MinIdNumber, Constants.MaxIdNumber));

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.ValidateNull(student, Constants.StudentNameCannotBeNull);

            Validator.ValidateIntRange(
                this.students.Count,
                Constants.MinStudentsInCourse,
                Constants.MaxStudentsInCourse,
                string.Format(Constants.NumberMustBeBetweenMinAndMax, "Students count in course", Constants.MinIdNumber, Constants.MaxIdNumber));

            if (!this.students.Contains(student))
            {
                throw new InvalidOperationException("The student cannot be removed from the course, as he/she is not attending it!");
            }

            this.students.Remove(student);
        }
    }
}
