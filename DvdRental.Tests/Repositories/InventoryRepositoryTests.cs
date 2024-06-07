using DvdRental.Library.Repositories;
using DvdRental.Library.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class InventoryRepositoryTests
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
            var repo = new InventoryRepository(new DbContextFactory(_configuration));

            var inventory = repo.GetById(3);
            var inventoryJson = JsonConvert.SerializeObject(inventory);

            Assert.IsNotNull(inventory);
        }
    }
}
