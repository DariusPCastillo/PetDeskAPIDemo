using Darius_PetDesk.Data;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit.Abstractions;
using System.Text.Json;
using Darius_PetDesk.Models;

namespace PetDeskTests
{
    public class AppointmentContextTests : AppointmentContextTestBase
    {

        public AppointmentContextTests(ITestOutputHelper output) : base(output) {

        }

        //Arrange, Act, Assert
        //Failed Test on Purpose Should().ThrowAsync<JsonException>();
        [Fact]
        public async Task GetAppointment_ok()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            HttpResponseMessage result = new HttpResponseMessage();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://723fac0a-1bff-4a20-bdaa-c625eae11567.mock.pstmn.io/appointments")
            };

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(_ => _.CreateClient("AppointmentContext")).Returns(httpClient);
            
            var data = new AppointmentContext(_config,_logger, mockHttpClientFactory.Object);

            var action = () => data.GetAppointment(cToken);
            await action.Should().ThrowAsync<JsonException>();
        }

    }
}