using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;
using DvdRental.Library.Models;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class AddressRepositoryTests
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
            var repo = new AddressRepository(new DbContextFactory(_configuration));

            var address = repo.GetById(3);
            var addressJson = JsonConvert.SerializeObject(address);

            Assert.IsNotNull(address);
        }
    }
}
