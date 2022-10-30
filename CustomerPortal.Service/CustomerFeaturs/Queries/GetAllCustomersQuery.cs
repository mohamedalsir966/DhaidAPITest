using AutoMapper;
using CustomerPortal.Domain.Entities;
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
   
    public class GetAllCustomersQuery : IRequest<PagedResponse<List<CustomerEntityDto>>>
    {
        public QueryStringParameters Qury { get; set; }
    }
    public class GetAllVaccinationQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<List<CustomerEntityDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICoustomerRepository _CoustomerRepository;
        public GetAllVaccinationQueryHandler(IApplicationDbContext context, IMapper mapper, ICoustomerRepository  coustomerRepository)
        {
            _context = context;
            _mapper = mapper;
            _CoustomerRepository = coustomerRepository;
        }
        public async Task<PagedResponse<List<CustomerEntityDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var queryParams = request.Qury;
            var customer = await _CoustomerRepository.GetAllCoustomersQuery(queryParams);
            if (customer == null)
            {
                return new PagedResponse<List<CustomerEntityDto>>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }


            return new PagedResponse<List<CustomerEntityDto>>
            {
                Data = _mapper.Map<List<CustomerEntityDto>>(customer),
                StatusCode = 200,
                CurrentPage = customer.CurrentPage,
                TotalPages = customer.TotalPages,
                PageSize = customer.PageSize,
                TotalCount = customer.TotalCount,
                HasPrevious = customer.HasPrevious,
                HasNext = customer.HasNext,
                Message = "Data found"
            };
        }
    }
}
