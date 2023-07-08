using AutoMapper;
using EmployeeManagement.Application.CQRS.Positions.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.Position;
using EmployeeManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Positions.Handlers.Queries
{
    public class GetPositionListRequestHandler : IRequestHandler<GetPositionListRequest, List<PositionDTO>>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        public GetPositionListRequestHandler(IPositionRepository positionRepository, IMapper mapper) 
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<List<PositionDTO>> Handle(GetPositionListRequest request, CancellationToken cancellationToken)
        {
            var positions = await _positionRepository.GetAllAsync();
            return _mapper.Map<List<PositionDTO>>(positions);
        }
    }
}
