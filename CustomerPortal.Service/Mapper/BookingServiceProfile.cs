using AutoMapper;
using CustomerPortal.Domain.Entities;
using CustomerPortal.Service.Dto;
using CustomerPortal.Service.InspectorFeaturs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Service.Mapper
{
    public class BookingServiceProfile : Profile
    {
        public BookingServiceProfile()
        {

            CreateMap<AppointmentEntity, AppointmentEntityDto>();

            CreateMap<AppointmentEntity, CreateAppointmentServiceCommand>().ReverseMap();

        }
    }
}
