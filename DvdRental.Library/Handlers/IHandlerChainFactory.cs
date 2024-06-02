
namespace DvdRental.Library.Handlers
{
    public interface IHandlerChainFactory
    {
        IHandler CreateChain(HandlerType[] handlerTypes);
    }
}
