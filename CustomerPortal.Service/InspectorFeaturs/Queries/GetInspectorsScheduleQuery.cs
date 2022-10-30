using AutoMapper;
using CustomerPortal.Domain.Entities;
using CustomerPortal.Persistence.Repositories;
using CustomerPortal.Service.RequestService;
using CustomerPortal.Service.RequestService.Service;
using MediatR;
using Service.Dto.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerPortal.Service.InspectorFeaturs.Queries
{
    
    public class GetInspectorsScheduleQuery : IRequest<PagedResponse<List<InspectorShiftEntityResponse>>>
    {
        public QueryStringParameters Qury { get; set; }
    }
    public class GetInspectorsScheduleQueryHandler : IRequestHandler<GetInspectorsScheduleQuery, PagedResponse<List<InspectorShiftEntityResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository  _BookingRepository;
        private readonly IInspectorService  _InspectorService;
        public GetInspectorsScheduleQueryHandler(IMapper mapper, IAppointmentRepository  bookingRepository, IInspectorService  inspectorService)
        {
            _mapper = mapper;
            _BookingRepository = bookingRepository;
            _InspectorService = inspectorService;
        }
        public async Task<PagedResponse<List<InspectorShiftEntityResponse>>> Handle(GetInspectorsScheduleQuery query, CancellationToken cancellationToken)
        {

            var reqestServiceResponse = (await _InspectorService.GetRequstServiceAsync(query.Qury));

            if (reqestServiceResponse == null)
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
                Data = _mapper.Map<List<InspectorShiftEntityResponse>>(reqestServiceResponse.Data),
                StatusCode = 200,
                CurrentPage = reqestServiceResponse.CurrentPage,
                TotalPages = reqestServiceResponse.TotalPages,
                PageSize = reqestServiceResponse.PageSize,
                TotalCount = reqestServiceResponse.TotalCount,
                HasPrevious = reqestServiceResponse.HasPrevious,
                HasNext = reqestServiceResponse.HasNext,
                Message = "Data found"
            };


        }
    }
}
