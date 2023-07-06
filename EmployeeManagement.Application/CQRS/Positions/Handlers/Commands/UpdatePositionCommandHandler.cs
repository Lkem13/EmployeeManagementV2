using AutoMapper;
using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Positions.Handlers.Commands
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, Unit>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public UpdatePositionCommandHandler(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _positionRepository.GetAsync(request.PositionDTO.Id);

            _mapper.Map(request.PositionDTO, position);

            await _positionRepository.UpdateAsync(position);

            return Unit.Value;
        }
    }
}
