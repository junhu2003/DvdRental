using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;
using DvdRental.Library.Services;


namespace DvdRental.Tests
{
    [TestClass]
    public class DvdRentalChainHandlerFactoryTests
    {
        private Mock<IValidator<DvdRentalContext>>? _validatorMock;
        private MockHandler? _handler1;
        private MockHandler? _handler2;

        private Mock<IHandlerFactory> _handlerFactory = new Mock<IHandlerFactory>();

        private DvdRentalContext _context = new DvdRentalContext();
        [TestInitialize]
        public void TestInitialize()
        {
            _validatorMock = new Mock<IValidator<DvdRentalContext>>();
            _validatorMock.Setup(x => x.Validate(It.IsAny<DvdRentalContext>())).Returns(() => new FluentValidation.Results.ValidationResult() { });
            _handler1 = new MockHandler(HandlerType.InitDvdRentalHandler, _validatorMock.Object, Mock.Of<ILogger<MockHandler>>(), Mock.Of<IContextStatusService>());
            _handler2 = new MockHandler(HandlerType.FinalCalcHandler, _validatorMock.Object, Mock.Of<ILogger<MockHandler>>(), Mock.Of<IContextStatusService>());
            _handlerFactory.Setup(x => x.CreateHandler(It.Is<HandlerType>(x => x == HandlerType.InitDvdRentalHandler))).Returns(() => new MockHandler(HandlerType.InitDvdRentalHandler, _validatorMock.Object, Mock.Of<ILogger<MockHandler>>(), Mock.Of<IContextStatusService>()));
            _handlerFactory.Setup(x => x.CreateHandler(It.Is<HandlerType>(x => x == HandlerType.FinalCalcHandler))).Returns(() => new MockHandler(HandlerType.FinalCalcHandler, _validatorMock.Object, Mock.Of<ILogger<MockHandler>>(), Mock.Of<IContextStatusService>()));
            _context = new DvdRentalContext();
        }

        [TestMethod]
        public async Task TestMultiple()
        {
            await TestFactory(new[] { HandlerType.InitDvdRentalHandler, HandlerType.InitDvdRentalHandler, HandlerType.InitDvdRentalHandler, HandlerType.FinalCalcHandler }, 4);

            Assert.IsTrue(_context.HandlersExecuted.Count(x => x.Equals(HandlerType.InitDvdRentalHandler)) == 3);
            Assert.IsTrue(_context.HandlersExecuted.Count(x => x.Equals(HandlerType.FinalCalcHandler)) == 1);
        }


        [TestMethod]
        public async Task TestSingle()
        {
            await TestFactory(new[] { HandlerType.InitDvdRentalHandler }, 1);
            Assert.IsTrue(_context.HandlersExecuted.Count(x => x.Equals(HandlerType.InitDvdRentalHandler)) == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestNone()
        {

            var factory = new DvdRentalChainHandlerFactory(_handlerFactory.Object);

            var handler = factory.CreateChain(Array.Empty<HandlerType>());


        }

        private async Task TestFactory(HandlerType[] handlerTypes, int numberExecuted)
        {
            var factory = new DvdRentalChainHandlerFactory(_handlerFactory.Object);

            var handler = factory.CreateChain(handlerTypes);

            var result = await handler.Handle(_context);

            Assert.IsTrue(result.HandlersExecuted.Count == numberExecuted);
        }

    }
}
