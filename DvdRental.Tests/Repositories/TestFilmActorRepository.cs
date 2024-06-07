using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockFilmActorRepository : IFilmActorRepository
    {
        public List<FilmActor>? GetByFilmId(int id)
        {
            var data = TestUtils.JsonFileToObject<List<FilmActor>>(@"TestData\\FilmActors.json");

            return data;
        }
    }
}
