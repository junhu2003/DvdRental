using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public Category? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Category>(@"TestData\\Category.json");

            return data;
        }
    }
}
