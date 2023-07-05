using AutoMapper;
using EmployeeManagement.Application.CQRS.Positions.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Positions.Handlers.Queries
{
    public class GetPositionDetailRequestHandler : IRequestHandler<GetPositionDetailRequest, PositionDTO>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        public GetPositionDetailRequestHandler(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<PositionDTO> Handle(GetPositionDetailRequest request, CancellationToken cancellationToken)
        {
            var position = await _positionRepository.GetAsync(request.Id);
            return _mapper.Map<PositionDTO>(position);
        }
    }
}
