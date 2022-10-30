using AutoMapper;
using MediatR;
using Service.Dto.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inspector.Service.Dto;
using Inspector.Domain.Helpers;
using Inspector.Persistence.Repositories;

namespace Inspector.Service.InspectorShiftFeaturs.Queries
{
    public class GetAllInspectorShiftQuery : IRequest<PagedResponse<List<InspectorShiftEntityResponse>>>
    {
        public QueryStringParameters Qury { get; set; }
    }
    public class GetAllInspectorShiftQueryHandler : IRequestHandler<GetAllInspectorShiftQuery, PagedResponse<List<InspectorShiftEntityResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectorShiftServiceRepository    _InspectorShiftServiceRepository;
        public GetAllInspectorShiftQueryHandler(IMapper mapper, IInspectorShiftServiceRepository  inspectorShiftServiceRepository)
        {
            _mapper = mapper;
            _InspectorShiftServiceRepository = inspectorShiftServiceRepository;

        }
        public async Task<PagedResponse<List<InspectorShiftEntityResponse>>> Handle(GetAllInspectorShiftQuery request, CancellationToken cancellationToken)
        {
            var queryParams = request.Qury;
            var inspectorShift = await _InspectorShiftServiceRepository.GetAllInspectorShiftQuery(queryParams);

            if (inspectorShift == null)
            {
                return new PagedResponse<List<InspectorShiftEntityResponse>>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

            return new PagedResponse<List<InspectorShiftEntityResponse>>
            {
                Data = _mapper.Map<List<InspectorShiftEntityResponse>>(inspectorShift),
                CurrentPage = inspectorShift.CurrentPage,
                TotalPages = inspectorShift.TotalPages,
                PageSize = inspectorShift.PageSize,
                TotalCount = inspectorShift.TotalCount,
                HasPrevious = inspectorShift.HasPrevious,
                HasNext = inspectorShift.HasNext,
                StatusCode = 200,
                Message = "Data found"
            };
        }

    }
}
