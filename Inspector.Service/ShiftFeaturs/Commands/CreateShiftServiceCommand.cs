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

namespace Inspector.Service.ShiftFeaturs.Commands
{
    
    public class CreateShiftServiceCommand : IRequest<Response<ShiftEntityDto>>
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Name { get; set; }
        public ShiftType ShiftType { get; set; }
    }

    public class CreateShiftServiceCommandHandler : IRequestHandler<CreateShiftServiceCommand, Response<ShiftEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IShiftServiceRepository   _ShiftServiceRepository;
        public CreateShiftServiceCommandHandler(IMapper mapper, IShiftServiceRepository  shiftServiceRepository)
        {
            _mapper = mapper;
            _ShiftServiceRepository = shiftServiceRepository;
        }
        public async Task<Response<ShiftEntityDto>> Handle(CreateShiftServiceCommand command, CancellationToken cancellationToken)
        {
            var shift = _mapper.Map<ShiftEntity>(command);
            await _ShiftServiceRepository.CreateNewShiftCommand(shift);

            return new Response<ShiftEntityDto>
            {
                Data = _mapper.Map<ShiftEntityDto>(shift),
                StatusCode = 200,
                Message = "Data has been added"
            };
        }
    }
}
