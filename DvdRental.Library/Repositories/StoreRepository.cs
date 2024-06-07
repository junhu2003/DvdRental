using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class StoreRepository : RepositoryBase, IStoreRepository
    {
        public StoreRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Store? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Stores.Where(s => s.StoreId == id).FirstOrDefault();
            }
        }
    }
}
