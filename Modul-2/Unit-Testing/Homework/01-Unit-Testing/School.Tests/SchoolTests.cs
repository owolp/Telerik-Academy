namespace School.Tests
{
    using System;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_CreateSchool_ShouldNotThrowAnException()
        {
            var school = new School("Telerik-Academy");
        }

        [TestMethod]
        public void School_AddStudent_ShouldNotThrowAnException()
        {
            var school = new School("Telerik-Academy");
            var student = new Student("John Smith", 10000);

            school.Students.Add(student);
        }

        [TestMethod]
        public void School_RemoveStudent_ShouldNotThrowAnException()
        {
            var school = new School("Telerik-Academy");
            var student = new Student("John Smith", 10000);

            school.Students.Add(student);
            school.Students.Remove(student);
        }

        [TestMethod]
        public void School_AddStudent_ShouldAddStudentToSchoolAndTheNumberOfStudentsInTheSchoolShouldBeOne()
        {
            var school = new School("Telerik-Academy");
            var student = new Student("John Smith", 10000);

            school.AddStudent(student);

            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        public void School_AddStudent_ShouldThrowArgumentNullExceptionWhenAddingNullStudentObject()
        {
            var school = new School("Telerik-Academy");
            Student student = null;

            Assert.ThrowsException<ArgumentNullException>(() => school.AddStudent(student));
        }

        [TestMethod]
        public void School_AddStudent_ShouldThrowArgumentException_WhenReAddingTheSameStudentToTheSchool()
        {
            var school = new School("Telerik-Academy");
            var student = new Student("John Smith", 10000);

            school.AddStudent(student);

            Assert.ThrowsException<ArgumentException>(() => school.AddStudent(student));
        }

        [TestMethod]
        public void School_RemoveStudent_ShouldThrowArgumentNullExceptionWhenRemovingNullStudentObject()
        {
            var school = new School("Telerik-Academy");
            Student student = null;

            Assert.ThrowsException<ArgumentNullException>(() => school.RemoveStudent(student));
        }

        [TestMethod]
        public void School_RemoveStudent_ShouldRemoveStudentFromSchoolAndTheNumberOfStudentsInTheSchoolShouldBeZero()
        {
            var school = new School("Telerik-Academy");
            var student = new Student("John Smith", 10000);

            school.AddStudent(student);
            school.RemoveStudent(student);

            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        public void School_RemoveStudent_ShouldThrowArgumentException_WhenRemovingANotAddedStudentToTheSchool()
        {
            var school = new School("Telerik-Academy");
            var student = new Student("John Smith", 10000);

            Assert.ThrowsException<ArgumentException>(() => school.RemoveStudent(student));
        }
    }
}
