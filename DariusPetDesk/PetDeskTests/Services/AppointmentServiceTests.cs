using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using System.Text.Json;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Darius_PetDesk.Data;
using Darius_PetDesk.Models;
using Darius_PetDesk.Services;
using Darius_PetDesk.Data.Interfaces;

namespace PetDeskTests.Services
{
    public class AppointmentServiceTests
    {
        private readonly ITestOutputHelper _output;
        private ILogger<IAppointmentContext> _logger => _output.GetLogger<IAppointmentContext>();
        private ILogger<AppointmentService> logger => _output.GetLogger<AppointmentService>();
       

        public AppointmentServiceTests(ITestOutputHelper output)
        {
            _output = output;
         
        }
        [Fact]
        public async Task AppointmentList_ok()
        {
            Root request = new Root()
            {
                appointmentId = 290321,
                appointmentType = "Trim Cut",
                createDateTime = DateTime.UtcNow,
                requestedDateTimeOffset = DateTime.UtcNow,
                user_UserId = 115066,
                user = new User { firstName = "Tracey", lastName = "Polzin", userId = 115066, vetDataId = "43404f83-63ae-4558-8fcd-071010100ad8" },
                animal_AnimalId = 137900,
                animal = new Animal { animalId = 137900, firstName = "Jackson", species = "Dog", breed = "Germnan Shepard" }
            };
            var apCtx = new Mock<IAppointmentContext>().Object;
            var service = new AppointmentService(apCtx, logger);
            var act = await service.AppointmentList();
            act.Should().NotBeNull();
            _output.WriteLine(JsonSerializer.Serialize(act));
        }
    }
}
