using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface ICountryRepository
    {
        Country? GetById(int id);
    }
}
