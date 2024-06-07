using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class CountryRepository : RepositoryBase, ICountryRepository
    {
        public CountryRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Country? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Countries.Where(a => a.CountryId == id).FirstOrDefault();
            }
        }
    }
}
