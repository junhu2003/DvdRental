using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class FilmCategoryRepository : RepositoryBase, IFilmCategoryRepository
    {
        public FilmCategoryRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public List<FilmCategory>? GetByFilmId(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.FilmCategories.Where(a => a.FilmId == id).ToList();
            }
        }
    }
}
