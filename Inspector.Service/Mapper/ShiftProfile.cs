using AutoMapper;
using Inspector.Domain.Entities;
using Inspector.Service.Dto;
using Inspector.Service.InspectorFeaturs.Commands;
using Inspector.Service.InspectorShiftFeaturs.Commands;
using Inspector.Service.ShiftFeaturs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Service.Mapper
{
    
    public class ShiftProfile : Profile
    {
        public ShiftProfile()
        {

            CreateMap<ShiftEntity, ShiftEntityDto>();

            CreateMap<ShiftEntity, CreateShiftServiceCommand>().ReverseMap();

        }
    }
}
