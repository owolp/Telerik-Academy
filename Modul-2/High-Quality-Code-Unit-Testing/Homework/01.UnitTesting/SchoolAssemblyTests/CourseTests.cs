namespace SchoolAssemblyTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolAssembly;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [TestCategory("CourseTests")]
        public void Course_ShouldNotThrowAnException_WhenCreatingCourse()
        {
            var course = new Course("Unit-Testing");
        }

        [TestMethod]
        [TestCategory("CourseTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Course_ShouldThrowInvalidCourseNameException_WhenNameIsNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Course_ShouldThrowInvalidCourseNameException_WhenNameIsEmpty()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [TestCategory("CourseTests")]
        public void Student_ShouldReturnExpectedName()
        {
            var course = new Course("Unit-Testing");

            Assert.AreEqual("Unit-Testing", course.Name);
        }

        [TestMethod]
        [TestCategory("CourseTests")]
        public void Course_ShouldNotThrowException_WhenAddingStudentFromCourse()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course("Unit-Testing");

            course.AddStudent(student);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        [TestCategory("CourseTests")]
        public void Course_ShouldNotThrowException_WhenRemovingStudentFromCourse()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course("Unit-Testing");

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [TestCategory("CourseTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Course_ShouldThrowInvalidAddToCourseStudentException_WhenIdCourseIsNull()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course(null);

            course.AddStudent(student);
        }

        [TestMethod]
        [TestCategory("CourseTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Course_ShouldThrowInvalidRemoveFromCourseStudentException_WhenIdCourseIsNull()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course(null);

            course.RemoveStudent(student);
        }

        [TestMethod]
        [TestCategory("CourseTests")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Course_ShouldThrowInvalidOperationExceptionIfStudentIsNotAttendingTheCourseFromWhichShouldBeRemoved()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course("Unit-Testing");

            student.RemoveFromCourse(course);
        }
    }
}
