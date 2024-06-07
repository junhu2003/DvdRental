using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockInventoryRepository : IInventoryRepository
    {
        public Inventory? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Inventory>(@"TestData\\Inventory.json");

            return data;
        }
    }
}
