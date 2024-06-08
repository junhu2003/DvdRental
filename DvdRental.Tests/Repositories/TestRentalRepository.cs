using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MocktRentalRepository : IRentalRepository
    {
        public List<Rental>? GetRentalByCustomer(int custId)
        {
            var data = TestUtils.JsonFileToObject<IEnumerable<Rental>>(@"TestData\\Rentals.json");

            return data?.ToList<Rental>();
        }

        public Rental? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<IEnumerable<Rental>>(@"TestData\\Rentals.json");

            return data?.Where(r => r.RentalId == id).FirstOrDefault();
        }
    }
}
