using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class StoreRepositoryTests
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
            var repo = new StoreRepository(new DbContextFactory(_configuration));

            var store = repo.GetById(2);
            var storeJson = JsonConvert.SerializeObject(store);

            Assert.IsNotNull(store);
        }
    }
}
