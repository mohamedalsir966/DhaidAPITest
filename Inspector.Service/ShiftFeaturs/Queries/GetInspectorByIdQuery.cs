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

namespace Inspector.Service.ShiftFeaturs.Queries
{

    public class GetShiftByIdQuery : IRequest<Response<ShiftEntityDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetShiftByIdQueryHandler : IRequestHandler<GetShiftByIdQuery, Response<ShiftEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IShiftServiceRepository   _ShiftServiceRepository;
        public GetShiftByIdQueryHandler(IMapper mapper, IShiftServiceRepository  shiftServiceRepository)
        {
            _mapper = mapper;
            _ShiftServiceRepository = shiftServiceRepository;
        }
        public async Task<Response<ShiftEntityDto>> Handle(GetShiftByIdQuery request, CancellationToken cancellationToken)
        {
            var shift = await _ShiftServiceRepository.GetShiftByIdQuery(request.Id);

            if (shift == null)
            {
                return new Response<ShiftEntityDto>
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "No data found"
                };
            }

            return new Response<ShiftEntityDto>
            {
                Data = _mapper.Map<ShiftEntityDto>(shift),
                StatusCode = 200,
                Message = "Data found"
            };
        }
    }
}
