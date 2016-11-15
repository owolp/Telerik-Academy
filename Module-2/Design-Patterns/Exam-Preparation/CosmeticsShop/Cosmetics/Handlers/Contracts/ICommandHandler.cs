namespace Cosmetics.Handlers.Contracts
{
    using Cosmetics.Contracts;

    public interface ICommandHandler
    {
        void SetSuccessor(ICommandHandler successor);

        string HandleRequest(ICommand command, IEngine engine);
    }
}