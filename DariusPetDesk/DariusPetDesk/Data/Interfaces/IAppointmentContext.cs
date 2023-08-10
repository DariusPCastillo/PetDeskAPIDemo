using Darius_PetDesk.Models;

namespace Darius_PetDesk.Data.Interfaces
{
    public interface IAppointmentContext
    {
        Task<IEnumerable<Root>> GetAppointment(CancellationToken cToken);
    }
}
