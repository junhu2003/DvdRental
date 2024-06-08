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

namespace Victor.Calculator.Tests
{
    [TestClass]
    public class CustomerRentalsHandlerTests
    {
        private Mock<ICustomerRepository>? _customerRepositoryMock;        
        private Mock<IAddressRepository>? _addressRepositoryMock;
        private Mock<ICityRepository>? _cityRepositoryMock;
        private Mock<ICountryRepository>? _countryRepositoryMock;
        private Mock<IStoreRepository>? _storeRepositoryMock;
        private Mock<IPaymentRepository>? _paymentRepositoryMock;
        private Mock<IStaffRepository>? _staffRepositoryMock;
        private Mock<IRentalRepository>? _rentalRepositoryMock;

        private Mock<ILogger<InitDvdRentalHandler>> _logger = new Mock<ILogger<InitDvdRentalHandler>>();
        private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();        

        [TestInitialize]
        public void Init()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _cityRepositoryMock = new Mock<ICityRepository>();
            _countryRepositoryMock = new Mock<ICountryRepository>();
            _storeRepositoryMock = new Mock<IStoreRepository>();
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            _staffRepositoryMock = new Mock<IStaffRepository>();
            _rentalRepositoryMock = new Mock<IRentalRepository>();
    }
                
        [TestMethod]
        public async Task TestContextInputsCustomerIdEqualsZeroFailed()
        {
            // _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => Task.FromResult<Actor?>(null));
            _customerRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Customer());
            _addressRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Address());
            _cityRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new City());
            _countryRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Country());
            _storeRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Store());
            _paymentRepositoryMock?.Setup(x => x.GetByCustomerId(It.IsAny<int>())).Returns(() => new List<Payment>());
            _staffRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new Staff());
            _rentalRepositoryMock?.Setup(x => x.GetRentalByCustomer(It.IsAny<int>())).Returns(() => new List<Rental>());

            var handler = new CustomerRentalsHandler(_logger.Object, _configuration.Object,
                _customerRepositoryMock?.Object, _addressRepositoryMock?.Object, _cityRepositoryMock?.Object, _countryRepositoryMock?.Object,
                _storeRepositoryMock?.Object, _paymentRepositoryMock?.Object, _staffRepositoryMock?.Object, _rentalRepositoryMock?.Object,
                DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());

            var result = await handler.Handle(new DvdRentalContext()
            {
                DateAccept = DateTime.MinValue,
                Inputs = new DvdRentalInputs() { CustomerId = 0 },
                Outputs = new DvdRentalOutputs() { }
            });

            Assert.IsTrue(result?.Outputs?.Errors?.Count == 1);

            Assert.IsTrue(result.HandlersExecuted.Count == 1);
        }
    }
}
