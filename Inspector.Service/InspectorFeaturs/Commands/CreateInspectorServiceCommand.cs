using AutoMapper;
using MediatR;
using Service.Dto.Common;
using System.Threading;
using System.Threading.Tasks;
using Inspector.Domain.Enum;
using Inspector.Domain.Entities;
using Inspector.Service.Dto;
using Inspector.Persistence.Repositories;

namespace Inspector.Service.InspectorFeaturs.Commands
{
    
    public class CreateInspectorServiceCommand : IRequest<Response<InspectorEntityDto>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }

    public class CreateInspectorServiceCommandHandler : IRequestHandler<CreateInspectorServiceCommand, Response<InspectorEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectorServiceRepository  _InspectorServiceRepository;
        public CreateInspectorServiceCommandHandler(IMapper mapper, IInspectorServiceRepository   inspectorServiceRepository)
        {
            _mapper = mapper;
            _InspectorServiceRepository = inspectorServiceRepository;
        }
        public async Task<Response<InspectorEntityDto>> Handle(CreateInspectorServiceCommand command, CancellationToken cancellationToken)
        {
            var inspector = _mapper.Map<InspectorEntity>(command);
            await _InspectorServiceRepository.CreateNewInspectorCommand(inspector);

            return new Response<InspectorEntityDto>
            {
                Data = _mapper.Map<InspectorEntityDto>(inspector),
                StatusCode = 200,
                Message = "Data has been added"
            };
        }
    }
}
