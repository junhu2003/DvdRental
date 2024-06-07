using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockFilmCategoryRepository : IFilmCategoryRepository
    {
        public List<FilmCategory>? GetByFilmId(int id)
        {
            var data = TestUtils.JsonFileToObject<List<FilmCategory>>(@"TestData\\FilmCategories.json");

            return data;
        }
    }
}
