namespace SchoolAssemblyTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolAssembly;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [TestCategory("SchoolTests")]
        public void School_ShouldNotThrowAnException_WhenCreatingSchool()
        {
            var school = new School("Telerik Academt");
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        public void School_ShouldReturnExpectedName()
        {
            var school = new School("Telerik Academt");

            Assert.AreEqual("Telerik Academt", school.Name);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void School_ShouldThrowInvalidNameException_WhenNameIsNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void School_ShouldThrowInvalidNameException_WhenNameIsEmpty()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        public void School_ShouldNotThrowException_WhenAddingStudentToSchool()
        {
            var student = new Student("John Smith", 10000);
            var school = new School("Telerik Academt");

            school.AddStudent(student);

            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        public void School_ShouldNotThrowException_WhenRemovingStudentFromSchool()
        {
            var student = new Student("John Smith", 10000);
            var school = new School("Telerik Academt");

            school.AddStudent(student);
            school.RemoveStudent(student);

            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void School_ShouldThrowInvalidAddStudentToSchoolException_WhenStudentIsNull()
        {
            Student student = null;
            var school = new School("Telerik Academt");

            school.AddStudent(student);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void School_ShouldThrowInvalidRemoveStudentToSchoolException_WhenStudentIsNull()
        {
            Student student = null;
            var school = new School("Telerik Academt");

            school.RemoveStudent(student);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Course_ShouldThrowInvalidOperationExceptionIfStudentIsNotAttendingTheSchoolFromWhichShouldBeRemoved()
        {
            var student = new Student("John Smith", 10000);
            var school = new School("Telerik Academt");

            school.RemoveStudent(student);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        public void School_ShouldNotThrowException_WhenAddingCourseToSchool()
        {
            var course = new Course("Unit-Testing");
            var school = new School("Telerik Academt");

            school.AddCourse(course);

            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        public void School_ShouldNotThrowException_WhenRemovingCourseFromSchool()
        {
            var course = new Course("Unit-Testing");
            var school = new School("Telerik Academt");

            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(0, school.Courses.Count);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void School_ShouldThrowInvalidAddStudentToSchoolException_WhenCourseIsNull()
        {
            Course course = null;
            var school = new School("Telerik Academt");

            school.AddCourse(course);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void School_ShouldThrowInvalidRemoveStudentToSchoolException_WhenCourseIsNull()
        {
            Course course = null;
            var school = new School("Telerik Academt");

            school.RemoveCourse(course);
        }

        [TestMethod]
        [TestCategory("SchoolTests")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Course_ShouldThrowInvalidOperationExceptionIfCourseIsNotAddedTheSchoolFromWhichShouldBeRemoved()
        {
            var course = new Course("Unit-Testing");
            var school = new School("Telerik Academt");

            school.RemoveCourse(course);
        }
    }
}
