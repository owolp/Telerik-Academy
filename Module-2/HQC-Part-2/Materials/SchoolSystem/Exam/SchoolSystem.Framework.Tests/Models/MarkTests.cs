using System;
using NUnit.Framework;
using SchoolSystem.Framework.Models;

namespace SchoolSystem.Framework.Tests.Models
{
    [TestFixture]
    public class MarkTests
    {
        [TestCase(1f)]
        [TestCase(7f)]
        [TestCase(1.99f)]
        [TestCase(6.000001f)]
        public void Constructor_ShouldThrow_WhenValueParameterIsOutOfRange(float value)
        {
            Assert.That(() => new Mark(value), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}