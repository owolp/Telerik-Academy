namespace School.Tests
{
    using System;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_CreateCourse_ShouldNotThrowAnException()
        {
            var course = new Course("Unit-Testing");
        }

        [TestMethod]
        public void Course_AddStudent_ShouldNotThrowAnException()
        {
            var course = new Course("Unit-Testing");
            var student = new Student("John Smith", 10000);

            course.Students.Add(student);
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldNotThrowAnException()
        {
            var course = new Course("Unit-Testing");
            var student = new Student("John Smith", 10000);

            course.Students.Add(student);
            course.Students.Remove(student);
        }

        [TestMethod]
        public void Course_AddStudent_ShouldAddStudentToCourseAndTheNumberOfStudentsInTheCourseShouldBeOne()
        {
            var course = new Course("Unit-Testing");
            var student = new Student("John Smith", 10000);

            course.AddStudent(student);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void Course_AddStudent_ShouldThrowArgumentNullExceptionWhenAddingNullStudentObject()
        {
            var course = new Course("Unit-Testing");
            Student student = null;

            Assert.ThrowsException<ArgumentNullException>(() => course.AddStudent(student));
        }

        [TestMethod]
        public void Course_AddStudent_ShouldThrowArgumentOutOfRangeException_WhenAddingMoreThan30StudentsToACourse()
        {
            var course = new Course("Unit-Testing");
            var student = new Student("John Smith", 10000);

            for (int i = 0; i <= Constants.MaxStudentsInCourse; i++)
            {
                course.AddStudent(new Student($"{i}", Constants.MinIdNumber + i));
            }

            Assert.ThrowsException<ArgumentException>(() => course.AddStudent(student));
        }

        [TestMethod]
        public void Course_AddStudent_ShouldThrowArgumentException_WhenReAddingTheSameStudentToTheCourse()
        {
            var course = new Course("Unit-Testing");
            var student = new Student("John Smith", 10000);

            course.AddStudent(student);

            Assert.ThrowsException<ArgumentException>(() => course.AddStudent(student));
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldThrowArgumentNullExceptionWhenRemovingNullStudentObject()
        {
            var course = new Course("Unit-Testing");
            Student student = null;

            Assert.ThrowsException<ArgumentNullException>(() => course.RemoveStudent(student));
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldRemoveStudentFromCourseAndTheNumberOfStudentsInTheCourseShouldBeZero()
        {
            var course = new Course("Unit-Testing");
            var student = new Student("John Smith", 10000);

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldThrowArgumentException_WhenRemovingANotAddedStudentToTheCourse()
        {
            var course = new Course("Unit-Testing");
            var student = new Student("John Smith", 10000);

            Assert.ThrowsException<ArgumentException>(() => course.RemoveStudent(student));
        }
    }
}
