using System.Collections.Generic;

using SchoolSystem.Framework.Commands.Contracts;
using SchoolSystem.Framework.Engines.Contracts;

namespace SchoolSystem.Framework.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemEngine engine)
        {
            var idToRemove = int.Parse(parameters[0]);
            engine.RemoveTeacher(idToRemove);

            return $"Teacher with ID {idToRemove} was sucessfully removed.";
        }
    }
}
