using DvdRental.Library.Repositories;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using Newtonsoft.Json;
using DvdRental.Library.Models;

namespace DvdRental.Tests.Repositories
{
    [TestClass]
    public class FilmCategoryRepositoryTests
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
        public void TestGetByFilmIdSuccess()
        {
            var repo = new FilmCategoryRepository(new DbContextFactory(_configuration));

            var filmCategories = repo.GetByFilmId(3);
            var filmCategoriesJson = JsonConvert.SerializeObject(filmCategories);

            Assert.IsTrue(filmCategories?.Count > 0);
        }
    }
}
