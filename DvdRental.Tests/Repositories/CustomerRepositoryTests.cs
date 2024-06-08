using DvdRental.Library.Repositories;
using DvdRental.Library.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class CustomerRepositoryTests
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
        public void TestGetCustomerWithNoParaSuccess()
        {
            var repo = new CustomerRepository(new DbContextFactory(_configuration));

            var customerList = repo.GetCustomers(string.Empty, string.Empty, string.Empty);

            Assert.IsNotNull(customerList);
            Assert.IsNotNull(customerList.Count > 0);            
        }

        [TestMethod]
        [TestCategory(TestUtils.INTEGRATION_TEST)]
        public void TestGetCustomerWithFirstNameSuccess()
        {
            var repo = new CustomerRepository(new DbContextFactory(_configuration));            

            var customerList = repo.GetCustomers("jenn", string.Empty, string.Empty);

            Assert.IsNotNull(customerList);
            Assert.IsNotNull(customerList.Count > 0);            
        }

        [TestMethod]
        [TestCategory(TestUtils.INTEGRATION_TEST)]
        public void TestGetCustomerWithLastNameSuccess()
        {
            var repo = new CustomerRepository(new DbContextFactory(_configuration));            

            var customerList = repo.GetCustomers(string.Empty, "Wil", string.Empty);

            Assert.IsNotNull(customerList);
            Assert.IsNotNull(customerList.Count > 0);
        }

        [TestMethod]
        [TestCategory(TestUtils.INTEGRATION_TEST)]
        public void TestGetCustomerWithEmailSuccess()
        {
            var repo = new CustomerRepository(new DbContextFactory(_configuration));

            var customerList = repo.GetCustomers(string.Empty, string.Empty, "jack");
            var customerJson = JsonConvert.SerializeObject(customerList);

            Assert.IsNotNull(customerList);
            Assert.IsNotNull(customerList.Count > 0);
        }
    }
}
