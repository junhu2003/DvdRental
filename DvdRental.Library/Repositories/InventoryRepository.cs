using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class InventoryRepository : RepositoryBase, IInventoryRepository
    {
        public InventoryRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Inventory? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Inventories.Where(r => r.InventoryId == id).FirstOrDefault();
            }
        }
    }
}
