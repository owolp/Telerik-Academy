using System;

using NUnit.Framework;

using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Tests.Models
{
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenFirstNameParameterIsNotValid()
        {
            string firstName = null;
            var lastName = "lastName";
            var subject = SchoolSubjectType.Bulgarian;

            Assert.That(
                () => new Teacher(firstName, lastName, subject),
                Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_ShouldThrow_WhenLastNameParameterIsNotValid()
        {
            var firstName = "firstName";
            string lastName = null;
            var subject = SchoolSubjectType.Bulgarian;

            Assert.That(
                () => new Teacher(firstName, lastName, subject),
                Throws.ArgumentNullException);
        }

        [TestCase("a")]
        [TestCase("toooooooooooooooloooooooooooooooooooooongggggggggggggggggggggggggg")]
        public void Constructor_ShouldThrowWhen_FirstNameParameterLengthIsOutOfRange(string firstName)
        {
            var lastName = "lastName";
            var subject = SchoolSubjectType.Bulgarian;

            Assert.That(
                () => new Teacher(firstName, lastName, subject),
                Throws.InstanceOf<ArgumentException>());
        }

        [TestCase("a")]
        [TestCase("toooooooooooooooloooooooooooooooooooooongggggggggggggggggggggggggg")]
        public void Constructor_ShouldThrowWhen_LastNameParameterLengthIsOutOfRange(string lastName)
        {
            var firstName = "firstName";
            var subject = SchoolSubjectType.Bulgarian;

            Assert.That(
                () => new Teacher(firstName, lastName, subject),
                Throws.InstanceOf<ArgumentException>());
        }
    }
}
