namespace Dealership.Handlers.Contracts
{
    using Engine;

    public interface ICommandHandler
    {
        void SetSuccessor(BaseHandler successor);

        string HandleRequest(ICommand command, IEngine engine);
    }
}