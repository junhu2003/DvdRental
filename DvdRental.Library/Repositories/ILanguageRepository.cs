using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface ILanguageRepository
    {
        Language? GetById(int id);
    }
}
