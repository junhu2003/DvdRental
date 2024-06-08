using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class RentalRepository : RepositoryBase, IRentalRepository
    {
        public RentalRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public List<Rental>? GetRentalByCustomer(int custId)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Rentals.Where(r => r.CustomerId == custId).ToList();
            }
        }

        public Rental? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Rentals.Where(r => r.RentalId == id).FirstOrDefault();
            }
        }
    }
}
