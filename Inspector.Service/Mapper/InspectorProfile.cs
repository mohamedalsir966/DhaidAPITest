using AutoMapper;
using Inspector.Domain.Entities;
using Inspector.Service.Dto;
using Inspector.Service.InspectorFeaturs.Commands;

namespace Inspector.Service.Mapper
{
    public class InspectorProfile : Profile
    {
        public InspectorProfile()
        {

            CreateMap<InspectorEntity, InspectorEntityDto>();

            CreateMap<InspectorEntity, CreateInspectorServiceCommand>().ReverseMap();

        }
    }
}
