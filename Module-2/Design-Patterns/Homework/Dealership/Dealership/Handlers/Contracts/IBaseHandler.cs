namespace Dealership.Handlers.Contracts
{
    using Engine;

    public interface IBaseHandler
    {
        void SetSuccessor(BaseHandler successor);

        string HandleRequest(ICommand command, IEngine engine);
    }
}