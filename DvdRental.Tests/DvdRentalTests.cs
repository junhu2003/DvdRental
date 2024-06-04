using Moq;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;
using DvdRental.Library.Validators;

namespace DvdRental.Tests
{
    [TestClass]
    public class DvdRentalTests
    {
        private readonly Mock<IHandlerChainFactory> _handlerChainFactory = new();
        private readonly Mock<ILogger<DvdRental.Library.DvdRental>> _logger = new();
        private readonly Mock<IHandler> _handler1 = new();
        private readonly Mock<IHandler> _handler2 = new();

        [TestInitialize]
        public void TestInitialize()
        {
            _handler1.Setup(x => x.HandlerType).Returns(HandlerType.InitDvdRentalHandler);
            _handler1.Setup(x => x.Handle(It.IsAny<DvdRentalContext>())).Returns(_handler2.Object.Handle(It.IsAny<DvdRentalContext>()));
            _handler2.Setup(x => x.HandlerType).Returns(HandlerType.FinalCalcHandler);
            _handler2.Setup(x => x.Handle(It.IsAny<DvdRentalContext>())).Returns(Task.FromResult(new DvdRentalContext()));
            _handlerChainFactory.Setup(x => x.CreateChain(It.IsAny<HandlerType[]>())).Returns(_handler1.Object);

        }

        [TestMethod]
        public async Task TestCalculator()
        {
            var calculator = new DvdRental.Library.DvdRental(_handlerChainFactory.Object, _logger.Object, new DvdRentalInputsValidator());

            await calculator.Execute(new DvdRentalContext()
            {
                Inputs = new DvdRentalInputs()
                {
                    ActorId = 3
                }
            });
            //verify calculator calls each handler in chain
            _handler1.Verify(x => x.Handle(It.IsAny<DvdRentalContext>()), Times.Once());
            _handler2.Verify(x => x.Handle(It.IsAny<DvdRentalContext>()), Times.Once());

        }

    }
}
