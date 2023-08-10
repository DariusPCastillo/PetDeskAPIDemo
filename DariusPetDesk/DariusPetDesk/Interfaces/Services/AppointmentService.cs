using Darius_PetDesk.Data.Interfaces;
using Darius_PetDesk.Interfaces;
using Darius_PetDesk.Models;

namespace Darius_PetDesk.Services
{
    public class AppointmentService : IAppointment
    {
        private readonly ILogger _logger;
        private readonly IAppointmentContext _adata;


        public AppointmentService(IAppointmentContext context, ILogger<AppointmentService> logger)
        {
            _logger = logger;
            _adata = context;
        }

        public async Task<IEnumerable<Root>> AppointmentList(CancellationToken cToken)
        {
            return await _adata.GetAppointment(cToken);

        }
    }
}
