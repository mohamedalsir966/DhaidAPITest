using AutoMapper;
using MediatR;
using Service.Dto.Common;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inspector.Service.Dto;
using Inspector.Persistence.Repositories;

namespace Inspector.Service.InspectorFeaturs.Queries
{

    public class GetInspectorByIdQuery : IRequest<Response<InspectorEntityDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInspectorByIdQueryHandler : IRequestHandler<GetInspectorByIdQuery, Response<InspectorEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectorServiceRepository  _InspectorServiceRepository;
        public GetInspectorByIdQueryHandler(IMapper mapper, IInspectorServiceRepository  inspectorServiceRepository)
        {
            _mapper = mapper;
            _InspectorServiceRepository = inspectorServiceRepository;
        }
        public async Task<Response<InspectorEntityDto>> Handle(GetInspectorByIdQuery request, CancellationToken cancellationToken)
        {
            var inspector = await _InspectorServiceRepository.GetInspectorByIdQuery(request.Id);

            if (inspector == null)
            {
                return new Response<InspectorEntityDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

            return new Response<InspectorEntityDto>
            {
                Data = _mapper.Map<InspectorEntityDto>(inspector),
                StatusCode = 200,
                Message = "Data found"
            };
        }
    }
}
