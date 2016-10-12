using System.Collections.Generic;

using SchoolSystem.Framework.Engines.Contracts;

namespace SchoolSystem.Framework.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters, ISchoolSystemEngine engine);
    }
}
