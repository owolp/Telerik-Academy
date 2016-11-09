namespace Dealership.Handlers.Contracts
{
    public interface IHandlerFactory
    {
        ICommandHandler CreateAndAttachHandlers();
    }
}