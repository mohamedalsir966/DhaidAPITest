using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using AutoMapper;
using Inspector.Service.Mapper;
using Service.PipelineBehaviours;

namespace Inspector.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            var config = new MapperConfiguration(c => {
                c.AddProfile<InspectorProfile>();
                c.AddProfile<ShiftProfile>();
                c.AddProfile<InspectorShiftProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());
            
        }
    }
}
