using DvdRental.Library.Repositories;
using DvdRental.Library.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class RentalRepositoryTests
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
        public void TestGetRentalByCustomerSuccess()
        {
            var repo = new RentalRepository(new DbContextFactory(_configuration));

            var rentals = repo.GetRentalByCustomer(3);
            var rentalJson = JsonConvert.SerializeObject(rentals); 

            Assert.IsTrue(rentals?.Count > 0);
        }
    }
}
