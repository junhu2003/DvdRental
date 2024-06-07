using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockAddressRepository : IAddressRepository
    {
        public Address? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Address>(@"TestData\\Address.json");

            return data;
        }
    }
}
