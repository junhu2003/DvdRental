using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockCityRepository : ICityRepository
    {
        public City? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<City>(@"TestData\\City.json");

            return data;
        }
    }
}
