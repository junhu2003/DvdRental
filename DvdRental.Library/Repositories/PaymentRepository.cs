using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class PaymentRepository : RepositoryBase, IPaymentRepository
    {
        public PaymentRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public List<Payment>? GetByRentalId(int rentalId)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Payments.Where(a => a.RentalId == rentalId).ToList();
            }
        }

        public List<Payment>? GetByCustomerId(int custId)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Payments.Where(a => a.CustomerId == custId).ToList();
            }
        }
    }
}
