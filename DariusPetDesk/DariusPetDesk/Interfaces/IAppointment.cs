using Darius_PetDesk.Models;

namespace Darius_PetDesk.Interfaces
{
    public interface IAppointment
    {
        public Task<IEnumerable<Root>> AppointmentList(CancellationToken cToken);
    }
}
