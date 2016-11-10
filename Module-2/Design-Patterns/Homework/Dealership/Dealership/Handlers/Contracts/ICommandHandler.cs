namespace Dealership.Handlers.Contracts
{
    using Engine;

    public interface ICommandHandler
    {
        void SetSuccessor(ICommandHandler successor);

        string HandleRequest(ICommand command, IEngine engine);
    }
}