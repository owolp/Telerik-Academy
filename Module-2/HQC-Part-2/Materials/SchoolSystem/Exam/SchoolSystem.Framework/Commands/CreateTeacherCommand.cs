using System.Collections.Generic;

using SchoolSystem.Framework.Commands.Contracts;
using SchoolSystem.Framework.Engines;
using SchoolSystem.Framework.Engines.Contracts;

namespace SchoolSystem.Framework.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemEngine engine)
        {
            var teacher = SchoolSystemFactory.CreateTeacher(parameters);
            var id = engine.AddTeacher(teacher);

            var result = $"A new teacher with name {teacher.FirstName} {teacher.LastName}, subject {teacher.SchoolSubjectType} and ID {id} was created.";

            return result;
        }
    }
}