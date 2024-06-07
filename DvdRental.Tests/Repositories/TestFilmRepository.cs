using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockFilmRepository : IFilmRepository
    {
        public Film? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Film>(@"TestData\\Film.json");

            return data;
        }
    }
}
