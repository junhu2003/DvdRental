using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockLanguageRepository : ILanguageRepository
    {
        public Language? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Language>(@"TestData\\Language.json");

            return data;
        }
    }
}
