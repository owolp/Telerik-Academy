namespace SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_WhenValidInputIsPassed_ShouldCreateStudentWithNoExceptions()
        {
            var student = new Student("John Smith", 10000);
        }

        [TestMethod]
        public void Student_WhenValidNameIsProvided_ShouldReturnExpectedName()
        {
            var student = new Student("John Smith", 10000);

            Assert.AreEqual("John Smith", student.Name);
        }

        [TestMethod]
        public void Student_WhenValidIdIsProvided_ShouldReturnExpectedId()
        {
            var student = new Student("John Smith", 10000);

            Assert.AreEqual(10000, student.Id);
        }

        [TestMethod]
        public void Student_CreateStudentWithNullName_ShouldThrowNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() => new Student(null, 10000));
        }

        [TestMethod]
        public void Student_CreateStudentWithWithspaceName_ShouldThrowNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() => new Student("     ", 10000));
        }

        [TestMethod]
        public void Student_CreateStudentWithEmptyStringEmptyName_ShouldThrowNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() => new Student(string.Empty, 10000));
        }

        [TestMethod]
        public void Student_CreateStudentWithIdLessThanMinimumAllowed_ShouldThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Student("John Smith", 1000));
        }

        [TestMethod]
        public void Student_CreateStudentWithIdMoreThanMaximumAllowed_ShouldThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Student("John Smith", 100000));
        }

        [TestMethod]
        public void Student_AddToCourseWithNullCourse_ShouldThrowArgumentNullException()
        {
            var student = new Student("John Smith", 10000);
            Course course = null;

            Assert.ThrowsException<NullReferenceException>(() => course.AddStudent(student));
        }

        [TestMethod]
        public void Student_RemoveFromCourseWithNullCourse_ShouldThrowArgumentNullException()
        {
            var student = new Student("John Smith", 10000);
            Course course = null;

            Assert.ThrowsException<NullReferenceException>(() => course.RemoveStudent(student));
        }

        [TestMethod]
        public void Student_AddToCourse_ShouldAddStudentToCourseWithNoExceptions()
        {
            var student = new Student("John Sith", 10000);
            var course = new Course("Unit-Testing");

            course.AddStudent(student);
        }

        [TestMethod]
        public void Student_AddToCourse_ShouldAddStudentToCourseAndTheCountShouldBeOne()
        {
            var student = new Student("John Sith", 10000);
            var course = new Course("Unit-Testing");

            course.AddStudent(student);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void Student_RemoveFromCourse_ShouldRemoveStudentFromCourseWithNoExceptions()
        {
            var student = new Student("John Sith", 10000);
            var course = new Course("Unit-Testing");

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(0, course.Students.Count);
        }
    }
}
