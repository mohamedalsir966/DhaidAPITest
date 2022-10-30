using CustomerPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<AppointmentEntity> Appointment { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        Task<int> SaveChangesAsync();
    }
}
