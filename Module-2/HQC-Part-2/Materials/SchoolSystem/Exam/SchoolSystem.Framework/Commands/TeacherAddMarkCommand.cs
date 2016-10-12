using System.Collections.Generic;

using SchoolSystem.Framework.Commands.Contracts;
using SchoolSystem.Framework.Engines;
using SchoolSystem.Framework.Engines.Contracts;

namespace SchoolSystem.Framework.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemEngine engine)
        {
            var teecherid = int.Parse(parameters[0]);
            var studentid = int.Parse(parameters[1]);

            var student = engine.GetStudentWithId(studentid);
            var teacher = engine.GetTeacherWithId(teecherid);

            var markValue = float.Parse(parameters[2]);
            var mark = SchoolSystemFactory.CreateMark(markValue);
            teacher.AddMark(student, mark);

            var result = $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.SchoolSubjectType}.";
            return result;
        }
    }
}