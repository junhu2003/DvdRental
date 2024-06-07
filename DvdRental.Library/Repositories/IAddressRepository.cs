using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface IAddressRepository
    {
        Address? GetById(int id);
    }
}
