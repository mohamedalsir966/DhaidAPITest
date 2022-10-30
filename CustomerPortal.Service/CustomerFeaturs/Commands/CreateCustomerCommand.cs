using AutoMapper;
using CustomerPortal.Domain.Entities;
using CustomerPortal.Persistence.Repositories;
using CustomerPortal.Service.Dto;
using MediatR;
using Service.Dto.Common;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerPortal.Service.CustomerFeaturs.Commands
{
    public class CreateCustomerCommand : IRequest<Response<CustomerEntityDto>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public class CreateVaccinCommandCommandHandler : IRequestHandler<CreateCustomerCommand, Response<CustomerEntityDto>>
        {
            private readonly IMapper _mapper;
            private readonly ICoustomerRepository  _CoustomerRepository;
            public CreateVaccinCommandCommandHandler(IMapper mapper, ICoustomerRepository  coustomerRepository)
            {
                _mapper = mapper;
                _CoustomerRepository = coustomerRepository;
            }
            public async Task<Response<CustomerEntityDto>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<CustomerEntity>(command);
                await _CoustomerRepository.CreateNewCoustomerCommand(customer);
                return new Response<CustomerEntityDto>
                {
                    Data = _mapper.Map<CustomerEntityDto>(customer),
                    StatusCode = 200,
                    Message = "Data has been added"
                };


            }
        }
    }
}
