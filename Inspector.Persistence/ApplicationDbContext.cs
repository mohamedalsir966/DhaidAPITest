using Inspector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           Database.Migrate();
        }
        public DbSet<InspectorEntity> Inspector { get; set; }
        public DbSet<ShiftEntity> Shift { get; set; }
        public DbSet<InspectorShiftEntity> InspectorShif { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
       
    }
}
