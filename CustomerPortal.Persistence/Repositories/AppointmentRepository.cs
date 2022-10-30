using CustomerPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        private ISortHelper<AppointmentEntity> _sortHelper;
        public AppointmentRepository(ApplicationDbContext context, ISortHelper<AppointmentEntity> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }
        public async Task<AppointmentEntity> CreateAppointmentServiceCommand(AppointmentEntity booking)
        {
            _context.Appointment.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> GetAvailableResourcesAsync(DateTime startDateTime, DateTime endDateTime, Guid inspectorId)
        {
            var query = await _context.Appointment.
                          Where(x => x.InspectionStart > startDateTime && x.InspectionEnd < endDateTime ||
                          x.InspectionEnd > startDateTime && x.InspectionStart < endDateTime).ToListAsync();
            if (query.Any())
                return false;
            return true;

            
        }
    }
}
