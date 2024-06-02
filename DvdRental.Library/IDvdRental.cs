using DvdRental.Library.Models;

namespace DvdRental.Library
{
    //calc interface methods go here
    public interface IDvdRental
    {
        Task<DvdRentalContext> Execute(DvdRentalContext context);
    }
}
