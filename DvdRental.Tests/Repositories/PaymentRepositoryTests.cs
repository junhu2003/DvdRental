using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;
using DvdRental.Library.Models;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class PaymentRepositoryTests
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
        public void TestGetByRentalIdSuccess()
        {
            var repo = new PaymentRepository(new DbContextFactory(_configuration));

            var payments = repo.GetByRentalId(2829);
            var paymentsJson = JsonConvert.SerializeObject(payments);

            Assert.IsTrue(payments?.Count > 0);
        }

        [TestMethod]
        [TestCategory(TestUtils.INTEGRATION_TEST)]
        public void TestGetByCustomerIdSuccess()
        {
            var repo = new PaymentRepository(new DbContextFactory(_configuration));

            var payments = repo.GetByCustomerId(342);
            var paymentsJson = JsonConvert.SerializeObject(payments);

            Assert.IsTrue(payments?.Count > 0);
        }
    }
}
