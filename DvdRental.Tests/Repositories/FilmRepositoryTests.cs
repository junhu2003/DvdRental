using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class FilmRepositoryTests
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
        public void TestGetByIdSuccess()
        {
            var repo = new FilmRepository(new DbContextFactory(_configuration));

            var film = repo.GetById(3);
            var filmJson = JsonConvert.SerializeObject(film);

            Assert.IsNotNull(film);
        }
    }
}
