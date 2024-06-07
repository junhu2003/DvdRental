using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockStoreRepository : IStoreRepository
    {
        public Store? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Store>(@"TestData\\Store.json");

            return data;
        }
    }
}
