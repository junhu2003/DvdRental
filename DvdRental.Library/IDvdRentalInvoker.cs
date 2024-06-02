using DvdRental.Library.Models;

namespace DvdRental.Library
{
    public interface IDvdRentalInvoker
    {
        void SetCommand(ICommand command);

        Task<DvdRentalOutputs> ExecuteCommand();
    }
}
