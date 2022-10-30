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

namespace Inspector.Service.ShiftFeaturs.Commands
{
   
    public class DeleteShiftServiceByIdCommand : IRequest<Response<ShiftEntityDto>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteShiftServiceByIdCommandHandler : IRequestHandler<DeleteShiftServiceByIdCommand, Response<ShiftEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IShiftServiceRepository   _ShiftServiceRepository;
        public DeleteShiftServiceByIdCommandHandler(IMapper mapper, IShiftServiceRepository  shiftServiceRepository)
        {
            _mapper = mapper;
            _ShiftServiceRepository = shiftServiceRepository;
        }
        public async Task<Response<ShiftEntityDto>> Handle(DeleteShiftServiceByIdCommand request, CancellationToken cancellationToken)
        {
            var discountService = await _ShiftServiceRepository.GetShiftByIdQuery(request.Id);
            if (discountService != null && discountService.Id != Guid.Empty)
            {
                var deletedShift = await _ShiftServiceRepository.DeleteShitByIdCommand(discountService);

                return new Response<ShiftEntityDto>
                {
                    Data = _mapper.Map<ShiftEntityDto>(deletedShift),
                    StatusCode = 200,
                    Message = "Data has been Deleted"
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
