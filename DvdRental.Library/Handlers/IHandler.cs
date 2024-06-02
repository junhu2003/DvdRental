using System.Threading.Tasks;
using DvdRental.Library.Models;

namespace DvdRental.Library.Handlers
{
    public interface IHandler
    {
        HandlerType HandlerType { get; }
        void SetNextHandler(IHandler next);
        Task<DvdRentalContext> Handle(DvdRentalContext context);

    }
}
