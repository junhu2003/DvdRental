using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockActorRepository : IActorRepository
    {
        public Actor? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<IEnumerable<Actor>>(@"TestData\\Actors.json");

            return data?.Where(a => a.ActorId == id).FirstOrDefault();
        }

        public List<Actor>? GetAll()
        {
            var data = TestUtils.JsonFileToObject<IEnumerable<Actor>>(@"TestData\\Actors.json");

            return data?.ToList<Actor>();
        }
    }
}
