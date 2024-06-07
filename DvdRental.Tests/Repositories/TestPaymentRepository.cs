using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockPaymentRepository : IPaymentRepository
    {
        public List<Payment>? GetByRentalId(int rentalId)
        {
            var data = TestUtils.JsonFileToObject<List<Payment>>(@"TestData\\Payments.json");

            return data?.Where(a => a.RentalId == rentalId).ToList();
        }

        public List<Payment>? GetByCustomerId(int custId)
        {
            var data = TestUtils.JsonFileToObject<List<Payment>>(@"TestData\\Payments.json");

            return data?.Where(a => a.CustomerId == custId).ToList();
        }
    }
}
