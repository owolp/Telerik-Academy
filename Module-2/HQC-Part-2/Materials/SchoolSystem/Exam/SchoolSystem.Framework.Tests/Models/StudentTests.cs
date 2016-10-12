using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Tests.Models
{
    [TestFixture]
    public class StudentTests
    {
        [TestCase(0)]
        [TestCase(13)]
        [TestCase(150000)]
        public void Constructor_ShouldThrow_WhenGradeParameterIsOutOfRange(int grade)
        {
            var firstName = "firstName";
            var lastName = "lastName";

            Assert.That(() => new Student(firstName, lastName, (Grade)grade),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void AddMark_ShouldThrow_WhenMarkParameterIsNull()
        {
            IMark mark = null;

            var student = new Student("first", "last", (Grade)12);

            Assert.That(() => student.AddMark(mark), Throws.ArgumentNullException);
        }

        [Test]
        public void AddMark_ShouldThrow_WhenAttemptingToAddMoreThanTwentyMarks()
        {
            var fakeMarks = new List<IMark>();
            for (int i = 0; i < 20; i++)
            {
                var newMark = new Mock<IMark>();
                fakeMarks.Add(newMark.Object);
            }

            var fakeMark = new Mock<IMark>();
            var student = new Student("first", "last", (Grade)12);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var studentMarks = student.GetType().GetField("marks", bindingFlags);
            studentMarks.SetValue(student, fakeMarks);

            Assert.That(() => student.AddMark(fakeMark.Object), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ListMarks_ShouldReturnCorrectString_WhenStudentHasZeroMarks()
        {
            var student = new Student("first", "last", (Grade)12);

            var expectedResult = "This student has no marks.";
            var actualResult = student.ListMarks();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ListMarks_ShouldReturnCorrectString_WhenStudentHasOneMark()
        {
            var student = new Student("first", "last", (Grade)12);
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var studentMarks = student.GetType().GetField("marks", bindingFlags);

            var fakeMark = new Mock<IMark>();
            fakeMark.SetupGet(mark => mark.SchoolSubjectType).Returns(SchoolSubjectType.Bulgarian);
            fakeMark.SetupGet(mark => mark.Value).Returns(5f);

            studentMarks.SetValue(student, new List<IMark>() { fakeMark.Object });

            var expectedResult = $"{SchoolSubjectType.Bulgarian} => 5";
            var actualResult = student.ListMarks();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ListMarks_ShouldReturnCorrectString_WhenStudentHasMultipleMarks()
        {
            var student = new Student("first", "last", (Grade)12);
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var studentMarks = student.GetType().GetField("marks", bindingFlags);

            var fakeMarks = new List<IMark>();
            var fakeMarkSubject = SchoolSubjectType.Math;
            var fakeMarkValue = 5f;

            var expectedResultBuilder = new StringBuilder();
            for (int i = 0; i < 11; i++)
            {
                var fakeMark = new Mock<IMark>();
                fakeMark.SetupGet(mark => mark.SchoolSubjectType).Returns(fakeMarkSubject);
                fakeMark.SetupGet(mark => mark.Value).Returns(fakeMarkValue);

                fakeMarks.Add(fakeMark.Object);
                expectedResultBuilder.AppendLine($"{fakeMarkSubject} => {fakeMarkValue}");
            }

            studentMarks.SetValue(student, fakeMarks);

            var expectedResult = expectedResultBuilder.ToString().Trim();
            var actualResult = student.ListMarks();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
