using DvdRental.Library.Repositories;
using DvdRental.Library.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class ActorRepositoryTests
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
            var repo = new ActorRepository(new DbContextFactory(_configuration));

            var actor = repo.GetById(3);

            Assert.IsNotNull(actor);
        }

        [TestMethod]
        [TestCategory(TestUtils.INTEGRATION_TEST)]
        public void TestGetAllIdSuccess()
        {
            var repo = new ActorRepository(new DbContextFactory(_configuration));

            var actorList = repo.GetAll();
            var actorListJson = JsonConvert.SerializeObject(actorList);

            Assert.IsTrue(actorList.Any());
        }
    }
}
