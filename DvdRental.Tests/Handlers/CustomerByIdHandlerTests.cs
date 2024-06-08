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
    public class CustomerByIdHandlerTests
    {
        private Mock<ICustomerRepository>? _customerRepositoryMock;        

        private Mock<ILogger<InitDvdRentalHandler>> _logger = new Mock<ILogger<InitDvdRentalHandler>>();
        private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();        

        [TestInitialize]
        public void Init()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();            
    }
                
        [TestMethod]
        public async Task TestContextInputsCustomerIdEqualsZeroFailed()
        {
            // _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => Task.FromResult<Actor?>(null));
            _customerRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null); // should fail once here           

            var handler = new CustomerByIdHandler(_logger.Object, _configuration.Object, _customerRepositoryMock?.Object,                
                DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());

            var result = await handler.Handle(new DvdRentalContext()
            {
                DateAccept = DateTime.MinValue,                
                Inputs = new DvdRentalInputs() { CustomerId = 0 }, // should fail once here
                Outputs = new DvdRentalOutputs() { }
            });

            Assert.IsTrue(result?.Outputs?.Errors?.Count == 2);

            Assert.IsTrue(result.HandlersExecuted.Count == 1);
        }
    }
}
