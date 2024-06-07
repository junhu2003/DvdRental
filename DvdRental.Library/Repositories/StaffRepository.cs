using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class StaffRepository : RepositoryBase, IStaffRepository
    {
        public StaffRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Staff? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Staff.Where(a => a.StaffId == id).FirstOrDefault();
            }
        }
    }
}
