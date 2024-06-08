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
                var customers = _dbContext.Customers.ToList();

                if (!string.IsNullOrEmpty(firstName))
                {
                    customers = customers.Where(c => c.FirstName.ToLower().Contains(firstName.ToLower())).ToList();                    
                }

                if (!string.IsNullOrEmpty(lastName))
                { 
                    customers = customers.Where(c => c.LastName.ToLower().Contains(lastName.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(email))
                {
                    customers = customers.Where(c => c.Email.ToLower().Contains(email.ToLower())).ToList();
                }
                
                return customers;
            }
        }
    }
}
