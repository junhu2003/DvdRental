using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface IFilmCategoryRepository
    {
        List<FilmCategory>? GetByFilmId(int id);
    }
}
