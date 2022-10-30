using AutoMapper;
using MediatR;
using Service.Dto.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inspector.Service.Dto;
using Inspector.Domain.Helpers;
using Inspector.Persistence.Repositories;

namespace Inspector.Service.ShiftFeaturs.Queries
{
    public class GetAllShiftQuery : IRequest<PagedResponse<List<ShiftEntityDto>>>
    {
        public QueryStringParameters Qury { get; set; }
    }
    public class GetAllShiftQueryHandler : IRequestHandler<GetAllShiftQuery, PagedResponse<List<ShiftEntityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IShiftServiceRepository   _ShiftServiceRepository;
        public GetAllShiftQueryHandler(IMapper mapper, IShiftServiceRepository  shiftServiceRepository)
        {
            _mapper = mapper;
            _ShiftServiceRepository = shiftServiceRepository;

        }
        public async Task<PagedResponse<List<ShiftEntityDto>>> Handle(GetAllShiftQuery request, CancellationToken cancellationToken)
        {
            var queryParams = request.Qury;
            var shift = await _ShiftServiceRepository.GetAllShiftQuery(queryParams);

            if (shift == null)
            {
                return new PagedResponse<List<ShiftEntityDto>>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

            return new PagedResponse<List<ShiftEntityDto>>
            {
                Data = _mapper.Map<List<ShiftEntityDto>>(shift),
                CurrentPage = shift.CurrentPage,
                TotalPages = shift.TotalPages,
                PageSize = shift.PageSize,
                TotalCount = shift.TotalCount,
                HasPrevious = shift.HasPrevious,
                HasNext = shift.HasNext,
                StatusCode = 200,
                Message = "Data found"
            };
        }

    }
}
