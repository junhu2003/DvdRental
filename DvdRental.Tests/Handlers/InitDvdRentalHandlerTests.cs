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
        private Mock<IActorRepository>? _actorRepositoryMock;

        private Mock<ILogger<InitDvdRentalHandler>> _logger = new Mock<ILogger<InitDvdRentalHandler>>();
        private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();

        private MockActorRepository? _actorRepo;        

        [TestInitialize]
        public void Init()
        {
            _actorRepositoryMock = new Mock<IActorRepository>();            

            _actorRepo = new MockActorRepository();            
        }

        [TestMethod]
        public async Task TestNoActorData()
        {            
            // _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => Task.FromResult<Actor?>(null));
            _actorRepositoryMock?.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            _actorRepositoryMock?.Setup(x => x.GetAll()).Returns(() => new List<Actor>());

            var handler = new InitDvdRentalHandler(_logger.Object, _configuration.Object, _actorRepositoryMock?.Object, DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());
            var result = await handler.Handle(new DvdRentalContext()
            {
                Inputs = new DvdRentalInputs() { ActorId = 3 },
                Outputs = new DvdRentalOutputs() { }
            });

            Assert.IsTrue(result?.Outputs?.Errors?.Count == 1);

            Assert.IsTrue(result.HandlersExecuted.Count == 1);
        }        

        [TestMethod]
        public async Task InitDvdRentalHandler_initializes_using_test_data()
        {
            var handler = new InitDvdRentalHandler(_logger.Object, _configuration.Object, _actorRepo, DvdRentalContextValidatorCreator.Create(), Mock.Of<IContextStatusService>());
            var result = await handler.Handle(new DvdRentalContext()
            {
                Inputs = new DvdRentalInputs() { ActorId = 3 }
            });

            Assert.IsNotNull(result.Actor);            
        }
    }
}
