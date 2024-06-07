using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;
using DvdRental.Library.Models;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class CategoryRepositoryTests
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
            var repo = new CategoryRepository(new DbContextFactory(_configuration));

            var category = repo.GetById(3);
            var categoryJson = JsonConvert.SerializeObject(category);

            Assert.IsNotNull(category);
        }
    }
}
