using DvdRental.Library.Handlers;
using DvdRental.Library.Models;

namespace DvdRental.Library.Services
{
    public interface IContextStatusService
    {
        void StartContext(HandlerType handlerType, DvdRentalContext context);
        void EndContext(DvdRentalContext context);
    }
}
