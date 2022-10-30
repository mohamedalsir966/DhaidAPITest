using AutoMapper;
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
   
    public class DeleteInspectorServiceByIdCommand : IRequest<Response<InspectorEntityDto>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteInspectorServiceByIdCommandHandler : IRequestHandler<DeleteInspectorServiceByIdCommand, Response<InspectorEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectorServiceRepository  _InspectorServiceRepository;
        public DeleteInspectorServiceByIdCommandHandler(IMapper mapper, IInspectorServiceRepository  inspectorServiceRepository)
        {
            _mapper = mapper;
            _InspectorServiceRepository = inspectorServiceRepository;
        }
        public async Task<Response<InspectorEntityDto>> Handle(DeleteInspectorServiceByIdCommand request, CancellationToken cancellationToken)
        {
            var inspector = await _InspectorServiceRepository.GetInspectorByIdQuery(request.Id);
            if (inspector != null)
            {
                var deletedInspector = await _InspectorServiceRepository.DeleteInspectorByIdCommand(inspector);

                return new Response<InspectorEntityDto>
                {
                    Data = _mapper.Map<InspectorEntityDto>(deletedInspector),
                    StatusCode = 200,
                    Message = "Data has been Deleted"
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
