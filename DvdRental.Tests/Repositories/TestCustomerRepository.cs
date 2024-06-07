using DvdRental.Library.Models;
using DvdRental.Library.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DvdRental.Tests.Repositories
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public List<Customer>? GetCustomers(string firstName = "", string lastName = "", string email = "")
        {
            var data = TestUtils.JsonFileToObject<IEnumerable<Customer>>(@"TestData\\Customers.json");

            if (string.IsNullOrEmpty(email))
            {
                return data?.Where(c => c.FirstName.ToLower().Contains(firstName.ToLower())
                    && c.LastName.ToLower().Contains(lastName.ToLower())).ToList();
            }
            else
            {
                return data?.Where(c => c.FirstName.ToLower().Contains(firstName.ToLower())
                    && c.LastName.ToLower().Contains(lastName.ToLower())
                    && c.Email != null && c.Email.ToLower().Contains(email.ToLower())).ToList();
            }
        }
    }
}
