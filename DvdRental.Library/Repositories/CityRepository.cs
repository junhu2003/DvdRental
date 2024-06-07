using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class CityRepository : RepositoryBase, ICityRepository
    {
        public CityRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public City? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Cities.Where(a => a.CityId == id).FirstOrDefault();
            }
        }
    }
}
