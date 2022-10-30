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

namespace Inspector.Service.InspectorFeaturs.Commands
{
   
    public class UpdateInspectorServiceCommand : IRequest<Response<InspectorEntityDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
    public class UpdateInspectorServiceCommandHanelar : IRequestHandler<UpdateInspectorServiceCommand, Response<InspectorEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectorServiceRepository   _InspectorServiceRepository;
        public UpdateInspectorServiceCommandHanelar(IMapper mapper, IInspectorServiceRepository  inspectorServiceRepository)
        {
            _mapper = mapper;
            _InspectorServiceRepository = inspectorServiceRepository;

        }
        public async Task<Response<InspectorEntityDto>> Handle(UpdateInspectorServiceCommand command, CancellationToken cancellationToken)
        {
            var existingInspector = await _InspectorServiceRepository.GetInspectorByIdQuery(command.Id);

            if (existingInspector != null)
            {
                existingInspector.Name = command.Name;
                existingInspector.Address = command.Address;
                existingInspector.MobileNumber = command.MobileNumber;
                existingInspector.Gender = command.Gender;
                existingInspector.Email = command.Email;
                existingInspector.ModifiedOn = DateTime.UtcNow;

                var updatedInspector = await _InspectorServiceRepository.UpdateInspectorByIdCommand(existingInspector);

                return new Response<InspectorEntityDto>
                {
                    Data = _mapper.Map<InspectorEntityDto>(updatedInspector),
                    StatusCode = 200,
                    Message = "Data has been Updated"
                };
            }
            else
            {
                return new Response<InspectorEntityDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }
        }
    }
}
