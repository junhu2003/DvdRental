using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface ICategoryRepository
    {
        Category? GetById(int id);
    }
}
