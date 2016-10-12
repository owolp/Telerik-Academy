using SchoolSystem.Framework.Commands.Contracts;

namespace SchoolSystem.Framework.Engines.Contracts
{
    public interface ICommandProvider
    {
        ICommand FindCommandExecutorWithName(string commandName);
    }
}
