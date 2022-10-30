using AutoMapper;
using CustomerPortal.Persistence.Repositories;
using CustomerPortal.Service.Dto;
using MediatR;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerPortal.Service.CustomerFeaturs.Commands
{
   
    public class UpdateCustomerCommand : IRequest<Response<CustomerEntityDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

    }
    public class UpdateCustomerCommandHanelar : IRequestHandler<UpdateCustomerCommand, Response<CustomerEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICoustomerRepository _CoustomerRepository;
        public UpdateCustomerCommandHanelar(IMapper mapper, ICoustomerRepository  coustomerRepository)
        {
            _mapper = mapper;
            _CoustomerRepository = coustomerRepository;

        }
        public async Task<Response<CustomerEntityDto>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var existingCustomer = await _CoustomerRepository.GetCoustomerByIdQuery(command.Id);

            if (existingCustomer.Id != Guid.Empty)
            {
                existingCustomer.Name = command.Name;
                existingCustomer.Address = command.Address;
                existingCustomer.MobileNumber = command.MobileNumber;
                existingCustomer.ModifiedOn = DateTime.UtcNow;

                var updatedCustomer = await _CoustomerRepository.UpdateCoustomerByIdCommand(existingCustomer);

                return new Response<CustomerEntityDto>
                {
                    Data = _mapper.Map<CustomerEntityDto>(updatedCustomer),
                    StatusCode = 200,
                    Message = "Data has been Updated"
                };
            }
            else
            {
                return new Response<CustomerEntityDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }
        }
    }
}
