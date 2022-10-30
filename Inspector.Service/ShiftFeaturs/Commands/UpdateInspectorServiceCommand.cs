using AutoMapper;
using Inspector.Domain.Enum;
using Inspector.Persistence.Repositories;
using Inspector.Service.Dto;
using MediatR;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inspector.Service.ShiftFeaturs.Commands
{
   
    public class UpdateShiftServiceCommand : IRequest<Response<ShiftEntityDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ShiftType ShiftType { get; set; }
    }
    public class UpdateShiftServiceCommandHanelar : IRequestHandler<UpdateShiftServiceCommand, Response<ShiftEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IShiftServiceRepository    _ShiftServiceRepository;
        public UpdateShiftServiceCommandHanelar(IMapper mapper, IShiftServiceRepository  shiftServiceRepository)
        {
            _mapper = mapper;
            _ShiftServiceRepository = shiftServiceRepository;

        }
        public async Task<Response<ShiftEntityDto>> Handle(UpdateShiftServiceCommand command, CancellationToken cancellationToken)
        {
            var existingShit = await _ShiftServiceRepository.GetShiftByIdQuery(command.Id);

            if (existingShit != null)
            {
                existingShit.StartDateTime = command.StartDateTime;
                existingShit.EndDateTime = command.EndDateTime;
                existingShit.ShiftType = command.ShiftType;
                existingShit.Name = command.Name;
                existingShit.ModifiedOn = DateTime.UtcNow;

                var updatedshift = await _ShiftServiceRepository.UpdatShiftByIdCommand(existingShit);

                return new Response<ShiftEntityDto>
                {
                    Data = _mapper.Map<ShiftEntityDto>(updatedshift),
                    StatusCode = 200,
                    Message = "Data has been Updated"
                };
            }
            else
            {
                return new Response<ShiftEntityDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }
        }
    }
}
