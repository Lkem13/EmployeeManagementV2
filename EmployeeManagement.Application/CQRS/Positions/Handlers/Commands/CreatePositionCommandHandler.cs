using AutoMapper;
using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;
using EmployeeManagement.Application.Persistence.Repository;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Positions.Handlers.Commands
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, int>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public CreatePositionCommandHandler(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = _mapper.Map<Position>(request.PositionDTO);

            position = await _positionRepository.AddAsync(position);

            return position.Id;
        }
    }
}
