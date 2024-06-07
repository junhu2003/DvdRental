using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface ICityRepository
    {
        City? GetById(int id);
    }
}
