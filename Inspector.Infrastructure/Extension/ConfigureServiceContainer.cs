using Inspector.Domain.Entities;
using Inspector.Domain.Helpers;
using Inspector.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;


namespace Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
             IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("InspectorDb")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
      
        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            serviceCollection.AddScoped<IInspectorServiceRepository, InspectorServiceRepository>();
            serviceCollection.AddScoped<IShiftServiceRepository, ShiftServiceRepository>();
            serviceCollection.AddScoped<IInspectorShiftServiceRepository, InspectorShiftServiceRepository>();
            serviceCollection.AddScoped<ISortHelper<InspectorEntity>, SortHelper<InspectorEntity>>();
            serviceCollection.AddScoped<ISortHelper<ShiftEntity>, SortHelper<ShiftEntity>>();
            serviceCollection.AddScoped<ISortHelper<InspectorShiftEntity>, SortHelper<InspectorShiftEntity>>();

        }
    }
}
