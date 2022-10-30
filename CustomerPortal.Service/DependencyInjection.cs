using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using AutoMapper;
using CustomerPortal.Service.Mapper;

namespace Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            var config = new MapperConfiguration(c => {
                c.AddProfile<BookingServiceProfile>();
                c.AddProfile<CustomerServiceProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());
            
        }
    }
}
