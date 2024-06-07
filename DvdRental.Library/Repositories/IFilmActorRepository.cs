using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface IFilmActorRepository
    {
        List<FilmActor>? GetByFilmId(int id);
    }
}
