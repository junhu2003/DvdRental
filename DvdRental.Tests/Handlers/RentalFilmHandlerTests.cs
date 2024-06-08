using Moq;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using DvdRental.Library.Handlers;
using DvdRental.Library.Validators;
using DvdRental.Library.Repositories;
using DvdRental.Tests.Repositories;
using DvdRental.Library.CustomTypes;
using DvdRental.Library.Services;
using DvdRental.Tests;

namespace DvdRental.Tests.Handlers
{
    [TestClass]
    public class RentalFilmHandlerTests
    {
        private Mock<IInventoryRepository>? _inventoryRepositoryMock;
        private Mock<IFilmRepository>? _filmRepositoryMock;
        private Mock<IFilmCategoryRepository>? _filmCategoryRepositoryMock;
        private Mock<ICategoryRepository>? _categoryRepositoryMock;
        private Mock<ILanguageRepository>? _languageRepositoryMock;
        private Mock<IFilmActorRepository>? _filmActorRepositoryMock;
        private Mock<IActorRepository>? _actorRepositoryMock;
        private Mock<IStaffRepository>? _staffRepositoryMock;
        private Mock<ICustomerRepository>? _customerRepositoryMock;
        private Mock<IPaymentRepository>? _paymentRepositoryMock;

        private Mock<ILogger<InitDvdRentalHandler>> _logger = new Mock<ILogger<InitDvdRentalHandler>>();
        private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();        

        [TestInitialize]
        public void Init()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _filmRepositoryMock = new Mock<IFilmRepository>();
            _filmCategoryRepositoryMock = new Mock<IFilmCategoryRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _languageRepositoryMock = new Mock<ILanguageRepository>();
            _filmActorRepositoryMock = new Mock<IFilmActorRepository>();
            _actorRepositoryMock = new Mock<IActorRepository>();
            _staffRepositoryMock = new Mock<IStaffRepository>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _paymentRepositoryMock = new Mock<IPaymentRepository>();        
    }
                
        [TestMethod]
        public async Task TestContextInputsCustomerIdEqualsZeroFailed()
        {
            // _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => Task.FromResult<Actor?>(null));
            _inventoryRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Inventory());
            _filmRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Film());
            _filmCategoryRepositoryMock?.Setup(x => x.GetByFilmId(It.IsAny<int>())).Returns(() => new List<FilmCategory>());
            _categoryRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Category());
            _languageRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Language());
            _filmActorRepositoryMock?.Setup(x => x.GetByFilmId(It.IsAny<int>())).Returns(() => new List<FilmActor>());
            _staffRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Staff());
            _customerRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Customer());
            _paymentRepositoryMock?.Setup(x => x.GetByCustomerId(It.IsAny<int>())).Returns(() => new List<Payment>());

            var handler = new RentalFilmHandler(_logger.Object, _configuration.Object,
                _inventoryRepositoryMock?.Object, _filmRepositoryMock?.Object, _filmCategoryRepositoryMock?.Object,
                _categoryRepositoryMock?.Object, _languageRepositoryMock?.Object, _filmActorRepositoryMock?.Object,
                _actorRepositoryMock?.Object, _staffRepositoryMock?.Object, _customerRepositoryMock?.Object, _paymentRepositoryMock?.Object,
                DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());

            var result = await handler.Handle(new DvdRentalContext()
            {
                DateAccept = DateTime.MinValue,
                Rental = new Rental(),
                Inputs = new DvdRentalInputs() { RentalId = 0 }, // should fail once here
                Outputs = new DvdRentalOutputs() { }
            });

            Assert.IsTrue(result?.Outputs?.Errors?.Count == 1);

            Assert.IsTrue(result.HandlersExecuted.Count == 1);
        }
    }
}
