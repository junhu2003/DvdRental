using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class FilmActorRepository : RepositoryBase, IFilmActorRepository
    {
        public FilmActorRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public List<FilmActor>? GetByFilmId(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.FilmActors.Where(a => a.FilmId == id).ToList();
            }
        }
    }
}
