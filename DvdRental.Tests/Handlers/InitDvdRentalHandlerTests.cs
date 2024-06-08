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
    public class InitDvdRentalHandlerTests
    {
        private Mock<ILogger<InitDvdRentalHandler>> _logger = new Mock<ILogger<InitDvdRentalHandler>>();
        private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();        

        [TestInitialize]
        public void Init()
        {            
        }
                
        [TestMethod]
        public async Task TestDateAcceptedNotMinimalDate()
        {            
            // _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => Task.FromResult<Actor?>(null));            

            var handler = new InitDvdRentalHandler(_logger.Object, _configuration.Object, DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());
            var result = await handler.Handle(new DvdRentalContext()
            {
                DateAccept = DateTime.MinValue,
                Inputs = new DvdRentalInputs() { },
                Outputs = new DvdRentalOutputs() { }
            });

            Assert.IsTrue(result?.Outputs?.Errors?.Count == 0);

            Assert.IsTrue(result.HandlersExecuted.Count == 1);
        }
    }
}
