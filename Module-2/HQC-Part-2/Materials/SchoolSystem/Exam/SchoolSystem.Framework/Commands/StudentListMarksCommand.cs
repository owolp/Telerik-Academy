using System.Collections.Generic;

using SchoolSystem.Framework.Commands.Contracts;
using SchoolSystem.Framework.Engines.Contracts;

namespace SchoolSystem.Framework.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemEngine engine)
        {
            var idToFind = int.Parse(parameters[0]);
            var student = engine.GetStudentWithId(idToFind);

            var listedMarks = student.ListMarks();
            return listedMarks;
        }
    }
}