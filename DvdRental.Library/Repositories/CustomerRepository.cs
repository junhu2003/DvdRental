using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public List<Customer>? GetCustomers(string firstName = "", string lastName = "", string email = "")
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                if (string.IsNullOrEmpty(email))
                {
                    return _dbContext.Customers.Where(c => c.FirstName.ToLower().Contains(firstName.ToLower()) 
                        && c.LastName.ToLower().Contains(lastName.ToLower())).ToList();
                }
                else
                {
                    return _dbContext.Customers.Where(c => c.FirstName.ToLower().Contains(firstName.ToLower()) 
                        && c.LastName.ToLower().Contains(lastName.ToLower()) 
                        && c.Email != null && c.Email.ToLower().Contains(email.ToLower())).ToList();
                }
                
            }
        }
    }
}
