using DvdRental.Library.Models;
using DvdRental.Library.Repositories;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class FilmRepository : RepositoryBase, IFilmRepository
    {
        public FilmRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Film? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Films.Where(f => f.FilmId == id).FirstOrDefault();
            }
        }
    }
}
