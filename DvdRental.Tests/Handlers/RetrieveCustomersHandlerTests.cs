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
    public class RetrieveCustomersHandlerTests
    {
        private Mock<ICustomerRepository>? _customerRepositoryMock;

        private Mock<ILogger<InitDvdRentalHandler>> _logger = new Mock<ILogger<InitDvdRentalHandler>>();
        private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();

        private MockCustomerRepository? _customerRepo;        

        [TestInitialize]
        public void Init()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();            

            _customerRepo = new MockCustomerRepository();            
        }
                
        [TestMethod]
        public async Task TestCustomersNotNullSuccess()
        {            
            // _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => Task.FromResult<Actor?>(null));
            _customerRepositoryMock?.Setup(x => x.GetCustomers(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(() => new List<Customer>());            

            var handler = new RetrieveCustomersHandler(_logger.Object, _configuration.Object, _customerRepositoryMock?.Object, DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());
            var result = await handler.Handle(new DvdRentalContext()
            {           
                Inputs = new DvdRentalInputs() { },
                Outputs = new DvdRentalOutputs() { }
            });

            Assert.IsTrue(result?.Outputs?.Errors?.Count == 0);

            Assert.IsTrue(result.HandlersExecuted.Count == 1);
        }

        [TestMethod]
        public async Task TestCustomersNullFailed()
        {
            // _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => Task.FromResult<Actor?>(null));
            _customerRepositoryMock?.Setup(x => x.GetCustomers(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(() => null);

            var handler = new RetrieveCustomersHandler(_logger.Object, _configuration.Object, _customerRepositoryMock?.Object, DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());
            var result = await handler.Handle(new DvdRentalContext()
            {
                Inputs = new DvdRentalInputs() { },
                Outputs = new DvdRentalOutputs() { }
            });

            Assert.IsTrue(result?.Outputs?.Errors?.Count == 1);

            Assert.IsTrue(result.HandlersExecuted.Count == 1);
        }
                
        [TestMethod]
        public async Task RetrieveCustomersHandler_initializes_using_test_data()
        {
            var handler = new RetrieveCustomersHandler(_logger.Object, _configuration.Object, _customerRepo, DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());
            var result = await handler.Handle(new DvdRentalContext()
            {                
                Inputs = new DvdRentalInputs() 
                {  
                    CustomerFirstName = "jac",
                    CustomerLastName = "",
                    CustomerEmail = "",
                }
            });

            Assert.IsTrue(result.Customers.Count > 0);
        }        
    }
}
