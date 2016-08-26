namespace School
{
    using System.Collections.Generic;
    using Common;

    public class School
    {
        private ICollection<Student> students;
        private ICollection<Course> courses;

        public School(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
            this.courses = new List<Course>();
        }

        public string Name { get; private set; }

        public ICollection<Student> Students
        {
            get
            {
                // Return a copy of the students collection
                return new List<Student>(this.students);
            }
        }

        public ICollection<Course> Courses
        {
            get
            {
                // Return a copy of the courses collection
                return new List<Course>(this.courses);
            }
        }

        public void AddStudent(Student student)
        {
            Validator.ValidateNull(
                student,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "Student"));

            Validator.ValidateCollectionContainsStudent(
                this.students,
                student,
                Constants.StudentAttendingSchool);

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
                Constants.StudentNotAttendingSchool);

            this.students.Remove(student);
        }

        private void AddCourse(Course course)
        {
            Validator.ValidateNull(
                course,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "Course"));

            Validator.ValidateCollectionContainsCourse(
                this.courses,
                course,
                Constants.CourseAddedToSchool);

            this.courses.Add(course);
        }

        private void RemoveCourse(Course course)
        {
            Validator.ValidateNull(
                course,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "Course"));

            Validator.ValidateCollectionDoesNotContainCourse(
                this.courses,
                course,
                Constants.CourseNotAddedToSchool);

            this.courses.Remove(course);
        }
    }
}
