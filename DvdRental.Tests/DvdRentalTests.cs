using Moq;
using DvdRental.Library;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;
using DvdRental.Library.Validators;
using System.Reflection.Metadata;

namespace DvdRental.Tests
{
    [TestClass]
    public class DvdRentalTests
    {
        private readonly Mock<IHandlerChainFactory> _handlerChainFactory = new();
        private readonly Mock<ILogger<DvdRental.Library.DvdRental>> _logger = new();
        private readonly Mock<IHandler> _handler1 = new();
        private readonly Mock<IHandler> _handler2 = new();
        private readonly Mock<IHandler> _handler3 = new();

        [TestInitialize]
        public void TestInitialize()
        {
            _handler1.Setup(x => x.HandlerType).Returns(HandlerType.InitDvdRentalHandler);
            _handler1.Setup(x => x.Handle(It.IsAny<DvdRentalContext>())).Returns(_handler2.Object.Handle(It.IsAny<DvdRentalContext>()));
            _handler2.Setup(x => x.HandlerType).Returns(HandlerType.RetrieveCustomersHandler);
            _handler2.Setup(x => x.Handle(It.IsAny<DvdRentalContext>())).Returns(_handler3.Object.Handle(It.IsAny<DvdRentalContext>()));
            _handler3.Setup(x => x.HandlerType).Returns(HandlerType.FinalDvdRentalHandler);
            _handler3.Setup(x => x.Handle(It.IsAny<DvdRentalContext>())).Returns(Task.FromResult(new DvdRentalContext()));
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
                }
            }, Constants.RETRIEVE_CUSTOMERS_CHAIN);
            //verify calculator calls each handler in chain
            _handler1.Verify(x => x.Handle(It.IsAny<DvdRentalContext>()), Times.Once());
            _handler2.Verify(x => x.Handle(It.IsAny<DvdRentalContext>()), Times.Once());
            _handler3.Verify(x => x.Handle(It.IsAny<DvdRentalContext>()), Times.Once());

        }

    }
}
