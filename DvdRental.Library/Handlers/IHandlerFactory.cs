
namespace DvdRental.Library.Handlers
{
    public interface IHandlerFactory
    {
        IHandler CreateHandler(HandlerType handlerType);
    }
}
