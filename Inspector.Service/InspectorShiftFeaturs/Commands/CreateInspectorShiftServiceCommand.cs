using AutoMapper;
using MediatR;
using Service.Dto.Common;
using System.Threading;
using System.Threading.Tasks;
using Inspector.Domain.Enum;
using Inspector.Domain.Entities;
using Inspector.Service.Dto;
using Inspector.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Inspector.Service.InspectorShiftFeaturs.Commands
{
    
    public class CreateInspectorShiftServiceCommand : IRequest<Response<InspectorShiftEntityDto>>
    {
        public Guid InspectorId { get; set; }
        public Guid ShiftId { get; set; }
        public DateTime StartWeek { get; set; }
        public DateTime EndWeek { get; set; }
    }

    public class CreateInspectorShiftServiceCommandHandler : IRequestHandler<CreateInspectorShiftServiceCommand, Response<InspectorShiftEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectorShiftServiceRepository  _InspectorShiftServiceRepository;
        private readonly IInspectorServiceRepository  _InspectorServiceRepository;
        private readonly IShiftServiceRepository  _ShiftServiceRepository;
        public CreateInspectorShiftServiceCommandHandler(IMapper mapper, IInspectorShiftServiceRepository shiftServiceRepository, IInspectorServiceRepository inspectorServiceRepository, IShiftServiceRepository  shiftServiceRepository1)
        {
            _mapper = mapper;
            _InspectorShiftServiceRepository = shiftServiceRepository;
            _InspectorServiceRepository = inspectorServiceRepository;
            _ShiftServiceRepository = shiftServiceRepository1;
        }
        public async Task<Response<InspectorShiftEntityDto>> Handle(CreateInspectorShiftServiceCommand command, CancellationToken cancellationToken)
        {
           var inspector= await _InspectorServiceRepository.GetInspectorByIdQuery(command.InspectorId);
            var shift= await _ShiftServiceRepository.GetShiftByIdQuery(command.ShiftId);

            if (inspector!=null && shift!=null)
            {
                var inspectorShift = new InspectorShiftEntity();
                inspectorShift.ShiftEntityId= command.ShiftId;
                inspectorShift.InspectorEntityId = command.InspectorId;
                inspectorShift.StartWeek= command.StartWeek;
                inspectorShift.EndWeek= command.EndWeek;
                await _InspectorShiftServiceRepository.CreateInspectorShiftCommand(inspectorShift);

                return new Response<InspectorShiftEntityDto>
                {
                    Data = _mapper.Map<InspectorShiftEntityDto>(inspectorShift),
                    StatusCode = 200,
                    Message = "Data has been added"
                };

            }
            else
            {
                return new Response<InspectorShiftEntityDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

           
        }
    }
}
