using CustomerPortal.Domain.Entities;
using CustomerPortal.Persistence.Repositories;
using CustomerPortal.Service.RequestService.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Persistence;

namespace Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
             IConfiguration configuration)
        {
           
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("CustomerDb")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
      
        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            serviceCollection.AddScoped<IAppointmentRepository, AppointmentRepository>();
            serviceCollection.AddScoped<ICoustomerRepository, CoustomerRepository>();
            serviceCollection.AddScoped<IInspectorService, InspectorService>();
            serviceCollection.AddScoped<ISortHelper<AppointmentEntity>, SortHelper<AppointmentEntity>>();
            serviceCollection.AddScoped<ISortHelper<CustomerEntity>, SortHelper<CustomerEntity>>();

        }
    }
}
