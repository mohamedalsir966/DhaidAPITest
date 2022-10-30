using CustomerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Persistence.Repositories
{
    public interface IAppointmentRepository
    {
        Task<AppointmentEntity> CreateAppointmentServiceCommand(AppointmentEntity booking);
        Task<bool> GetAvailableResourcesAsync(DateTime startDateTime, DateTime endDateTime, Guid inspectorId);

    }
}
