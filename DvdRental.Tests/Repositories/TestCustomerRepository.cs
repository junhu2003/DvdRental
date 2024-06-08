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

            var customers = data.ToList();

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

        public Customer? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<IEnumerable<Customer>>(@"TestData\\Customers.json");

            return data?.Where(c => c.CustomerId == id).FirstOrDefault();
        }
    }
}
