using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class LanguageRepository : RepositoryBase, ILanguageRepository
    {
        public LanguageRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Language? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Languages.Where(a => a.LanguageId == id).FirstOrDefault();
            }
        }
    }
}
