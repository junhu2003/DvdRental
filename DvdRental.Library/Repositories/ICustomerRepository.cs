using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface ICustomerRepository
    {
        Customer? GetById(int id);
        List<Customer>? GetCustomers(string firstName = "", string lastName = "", string email = "");
    }
}
