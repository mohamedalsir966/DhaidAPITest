using Inspector.Domain.Entities;
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
        public DbSet<InspectorEntity> Inspector { get; set; }
        public DbSet<ShiftEntity> Shift { get; set; }
        public DbSet<InspectorShiftEntity> InspectorShif { get; set; }
        Task<int> SaveChangesAsync();
    }
}
