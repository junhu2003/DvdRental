using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;
using DvdRental.Library.Models;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class FilmActorRepositoryTests
    {
        private IConfiguration? _configuration;
        [TestInitialize]
        public void Init()
        {
            _configuration = new ConfigurationBuilder()
                .AddUserSecrets<ActorRepositoryTests>()
                .Build();
        }

        [TestMethod]
        [TestCategory(TestUtils.INTEGRATION_TEST)]
        public void TestGetByFilmIdSuccess()
        {
            var repo = new FilmActorRepository(new DbContextFactory(_configuration));

            var filmActors = repo.GetByFilmId(3);
            var filmActorsJson = JsonConvert.SerializeObject(filmActors);

            Assert.IsTrue(filmActors?.Count > 0);
        }
    }
}
