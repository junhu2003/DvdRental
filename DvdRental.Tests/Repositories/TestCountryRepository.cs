using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockCountryRepository : ICountryRepository
    {
        public Country? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Country>(@"TestData\\Country.json");

            return data;
        }
    }
}
