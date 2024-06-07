using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class StaffRepositoryTests
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
            var repo = new StaffRepository(new DbContextFactory(_configuration));

            var staff = repo.GetById(1);
            var staffJson = JsonConvert.SerializeObject(staff);

            Assert.IsNotNull(staff);
        }
    }
}
