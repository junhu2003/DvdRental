using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public AddressRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Address? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Addresses.Where(a => a.AddressId == id).FirstOrDefault();
            }
        }
    }
}
