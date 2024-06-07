using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer>? GetCustomers(string firstName = "", string lastName = "", string email = "");
    }
}
