namespace SchoolAssemblyTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolAssembly;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [TestCategory("StudentTests")]
        public void Student_ShouldNotThrowAnException_WhenCreatingStudent()
        {
            var student = new Student("John Smith", 10000);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        public void Student_ShouldReturnExpectedName()
        {
            var studentToBeValidated = new Student("John Smith", 10000);

            Assert.AreEqual("John Smith", studentToBeValidated.Name);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Student_ShouldThrowInvalidNameException_WhenNameIsNull()
        {
            var student = new Student(null, 10000);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Student_ShouldThrowInvalidNameException_WhenNameIsEmpty()
        {
            var student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        public void Student_ShouldReturnExpectedIdNumber()
        {
            var studentToBeValidated = new Student("John Smith", 10000);

            Assert.AreEqual(10000, studentToBeValidated.IdNumber);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_ShouldThrowInvalidIdException_WhenIdIsLessThanMinIdNumber()
        {
            var student = new Student("John Smith", 0);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_ShouldThrowInvalidIdException_WhenIdIsLessThanMaxIdNumber()
        {
            var student = new Student("John Smith", 100000);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        public void Student_ShouldNotThrowException_WhenAddingStudentFromCourse()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course("Unit-Testing");

            student.AddToCourse(course);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        public void Student_ShouldNotThrowException_WhenRemovingStudentFromCourse()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course("Unit-Testing");

            student.AddToCourse(course);
            student.RemoveFromCourse(course);

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Student_ShouldThrowInvalidAddStudentToCourseException_WhenIdCourseIsNull()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course(null);

            student.AddToCourse(course);
        }

        [TestMethod]
        [TestCategory("StudentTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void Student_ShouldThrowInvalidRemoveStudentFromCourseException_WhenIdCourseIsNull()
        {
            var student = new Student("John Smith", 10000);
            var course = new Course(null);

            student.RemoveFromCourse(course);
        }
    }
}
