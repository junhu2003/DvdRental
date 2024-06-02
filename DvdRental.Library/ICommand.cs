using DvdRental.Library.Models;

namespace DvdRental.Library
{
    public interface ICommand
    {
        Task<DvdRentalOutputs> Execute();
    }
}
