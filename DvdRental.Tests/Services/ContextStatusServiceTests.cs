using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Tests.Services
{
    [TestClass]
    public class ContextStatusServiceTests
    {
        private Mock<ILogger<ContextStatusService>> mockLogger = new Mock<ILogger<ContextStatusService>>();

        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void TestContextStatusServiceDiff()
        {
            mockLogger.Setup(x => x.IsEnabled(It.Is<LogLevel>(x => x.Equals(LogLevel.Debug)))).Returns(true);

            var contextStatusService = new ContextStatusService(mockLogger.Object);

            var context = new DvdRentalContext();
            context.Actor = new Actor() { FirstName = "ABC" };

            contextStatusService.StartContext(Library.Handlers.HandlerType.InitDvdRentalHandler, context);

            context.Actor.FirstName = "EFG";

            contextStatusService.EndContext(context);

            var expectedJson = JObject.Parse(@"{""Actor"": {
                            ""FirstName"": [
                              ""ABC"",
                              ""EFG""
                            ]
                          }
                        }").ToString();

            mockLogger.Verify(x => x.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => JObject.Parse(o.ToString().Replace("Json Differences:\n ", "")).ToString().Equals(expectedJson)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);


        }

    }

}
