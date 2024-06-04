using DvdRental.Library;
using DvdRental.Library.Models;
using Moq;

namespace DvdRental.Tests
{
    [TestClass]
    public class DvdRentalInvokerTests
    {
        private Mock<IDvdRental>? _dvdRental;

        [TestInitialize]
        public void Initialize()
        {
            _dvdRental = new Mock<IDvdRental>();
            _dvdRental.Setup(x => x.Execute(It.IsAny<DvdRentalContext>()));
        }

        [TestMethod]
        public async Task TestInvokeDvdRental()
        {
            DvdRentalInvoker ci = new DvdRentalInvoker();

            ci.SetCommand(new RunDvdRentalCommand(_dvdRental?.Object));

            await ci.ExecuteCommand();

            _dvdRental?.Verify(x => x.Execute(It.IsAny<DvdRentalContext>()), Times.Once());
        }
    }
}