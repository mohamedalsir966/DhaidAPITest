using AutoMapper;
using MediatR;
using Service.Dto.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerPortal.Persistence.Repositories;
using CustomerPortal.Domain.Entities;
using CustomerPortal.Service.RequestService.Service;
using CustomerPortal.Service.Dto;

namespace CustomerPortal.Service.InspectorFeaturs.Commands
{
    
    public class CreateAppointmentServiceCommand : IRequest<Response<AppointmentEntityDto>>
    {
        public Guid CustomerID { get; set; }
        public Guid InspectorID { get; set; }
        public Guid ShiftID { get; set; }
        public DateTime InspectionStart { get; set; }
        public DateTime InspectionEnd { get; set; }
        public string Location { get; set; }

    }

    public class CreateAppointmentServiceCommandHandler : IRequestHandler<CreateAppointmentServiceCommand, Response<AppointmentEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository  _AppointmentRepository;
        public CreateAppointmentServiceCommandHandler(IMapper mapper, IAppointmentRepository  appointmentRepository)
        {
            _mapper = mapper;
            _AppointmentRepository = appointmentRepository;
        }
        public async Task<Response<AppointmentEntityDto>> Handle(CreateAppointmentServiceCommand command, CancellationToken cancellationToken)
        {
           
            var appointment = _mapper.Map<AppointmentEntity>(command);
            //chick if the inpector is avilable
             var checkAvailability = await _AppointmentRepository.GetAvailableResourcesAsync(command.InspectionStart,command.InspectionEnd,command.CustomerID);
            if (checkAvailability == false)
                throw new Exception("This inspector is not available chose another time please");

            await _AppointmentRepository.CreateAppointmentServiceCommand(appointment);

            return new Response<AppointmentEntityDto>
            {
                Data = _mapper.Map<AppointmentEntityDto>(appointment),
                StatusCode = 200,
                Message = "Data has been added"
            };
        }
    }
}
