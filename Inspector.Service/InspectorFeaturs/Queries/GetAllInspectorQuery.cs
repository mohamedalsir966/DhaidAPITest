using AutoMapper;
using MediatR;
using Service.Dto.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inspector.Service.Dto;
using Inspector.Domain.Helpers;
using Inspector.Persistence.Repositories;

namespace Inspector.Service.InspectorFeaturs.Queries
{
    public class GetAllInspectorQuery : IRequest<PagedResponse<List<InspectorEntityDto>>>
    {
        public QueryStringParameters Qury { get; set; }
    }
    public class GetAllInspectorQueryHandler : IRequestHandler<GetAllInspectorQuery, PagedResponse<List<InspectorEntityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectorServiceRepository  _InspectorServiceRepository;
        public GetAllInspectorQueryHandler(IMapper mapper, IInspectorServiceRepository  inspectorServiceRepository)
        {
            _mapper = mapper;
            _InspectorServiceRepository = inspectorServiceRepository;

        }
        public async Task<PagedResponse<List<InspectorEntityDto>>> Handle(GetAllInspectorQuery request, CancellationToken cancellationToken)
        {
            var queryParams = request.Qury;
            var Inspector = await _InspectorServiceRepository.GetAllInspectorQuery(queryParams);

            if (Inspector == null)
            {
                return new PagedResponse<List<InspectorEntityDto>>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

            return new PagedResponse<List<InspectorEntityDto>>
            {
                Data = _mapper.Map<List<InspectorEntityDto>>(Inspector),
                CurrentPage = Inspector.CurrentPage,
                TotalPages = Inspector.TotalPages,
                PageSize = Inspector.PageSize,
                TotalCount = Inspector.TotalCount,
                HasPrevious = Inspector.HasPrevious,
                HasNext = Inspector.HasNext,
                StatusCode = 200,
                Message = "Data found"
            };
        }

    }
}
