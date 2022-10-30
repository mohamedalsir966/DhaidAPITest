using AutoMapper;
using CustomerPortal.Persistence.Repositories;
using CustomerPortal.Service.Dto;
using MediatR;
using Persistence;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerPortal.Service.CustomerFeaturs.Queries
{
   
    public class GetCustomerByIdQuery : IRequest<Response<CustomerEntityDto>>
    {
        public Guid VaccinId { get; set; }

        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerEntityDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICoustomerRepository _CoustomerRepository;
            public GetCustomerByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ICoustomerRepository  coustomerRepository)
            {
                _context = context;
                _mapper = mapper;
                _CoustomerRepository = coustomerRepository;
            }
            public async Task<Response<CustomerEntityDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await _CoustomerRepository.GetCoustomerByIdQuery(request.VaccinId);

                if (customer == null)
                {
                    return new Response<CustomerEntityDto>
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }

                return new Response<CustomerEntityDto>
                {
                    Data = _mapper.Map<CustomerEntityDto>(customer),
                    StatusCode = 200,
                    Message = "Data found"
                };
            }
        }

    }
}
