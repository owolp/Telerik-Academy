using System.Collections.Generic;

using SchoolSystem.Framework.Commands.Contracts;
using SchoolSystem.Framework.Engines;
using SchoolSystem.Framework.Engines.Contracts;

namespace SchoolSystem.Framework.Commands
{
    public class CreateStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemEngine engine)
        {
            var student = SchoolSystemFactory.CreateStudent(parameters);
            var id = engine.AddStudent(student);

            var result = $"A new student with name {student.FirstName} {student.LastName}, grade {student.Grade} and ID {id} was created.";

            return result;
        }
    }
}
