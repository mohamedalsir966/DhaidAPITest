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
   
    public class DeleteCustomerCommand : IRequest<Response<CustomerEntityDto>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<CustomerEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICoustomerRepository _CoustomerRepository;
        public DeleteCustomerCommandHandler(IMapper mapper, ICoustomerRepository  coustomerRepository)
        {
            _mapper = mapper;
            _CoustomerRepository = coustomerRepository;
        }
        public async Task<Response<CustomerEntityDto>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _CoustomerRepository.GetCoustomerByIdQuery(request.Id);
            if (customer != null)
            {
                var deletedCustomer = await _CoustomerRepository.DeleteCoustomerByIdCommand(customer);

                return new Response<CustomerEntityDto>
                {
                    Data = _mapper.Map<CustomerEntityDto>(deletedCustomer),
                    StatusCode = 200,
                    Message = "Data has been Deleted"
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
