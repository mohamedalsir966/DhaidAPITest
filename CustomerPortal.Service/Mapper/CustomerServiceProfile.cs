using AutoMapper;
using CustomerPortal.Domain.Entities;
using CustomerPortal.Service.CustomerFeaturs.Commands;
using CustomerPortal.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Service.Mapper
{
   
    public class CustomerServiceProfile : Profile
    {
        public CustomerServiceProfile()
        {

            CreateMap<CustomerEntity, CustomerEntityDto>();

            CreateMap<CustomerEntity, CreateCustomerCommand>().ReverseMap();

        }
    }
}
