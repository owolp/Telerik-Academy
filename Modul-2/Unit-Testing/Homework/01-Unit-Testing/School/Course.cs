namespace School
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Course
    {
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public string Name { get; set; }

        public void AddStudent(Student student)
        {
            Validator.ValidateNull(
                student,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "Student"));

            Validator.ValidateIntRange(
                this.students.Count(),
                Constants.MinStudentsInCourse,
                Constants.MaxStudentsInCourse,
                Constants.CourseMaxStudentsAdded);

            Validator.ValidateCollectionContainsStudent(
                this.students,
                student,
                Constants.StudentAttendingCourse);

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.ValidateNull(
                student,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "Student"));

            Validator.ValidateCollectionDoesNotContainsStudent(
                this.students,
                student,
                Constants.StudentNotAttendingCourse);

            this.students.Remove(student);
        }
    }
}
