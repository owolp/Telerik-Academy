using System.Collections.Generic;

using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Engines
{
    public static class SchoolSystemFactory
    {
        public static IStudent CreateStudent(IList<string> parameters)
        {
            var student = new Student(parameters[0], parameters[1], (Grade)int.Parse(parameters[2]));
            return student;
        }

        public static ITeacher CreateTeacher(IList<string> parameters)
        {
            var teacher = new Teacher(parameters[0], parameters[1], (SchoolSubjectType)int.Parse(parameters[2]));
            return teacher;
        }

        public static IMark CreateMark(float value)
        {
            var mark = new Mark(value);
            return mark;
        }
    }
}
