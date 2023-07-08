using AutoMapper;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;

namespace EmployeeManagement.Application.CQRS.Positions.Handlers.Commands
{
        public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
        {
            private readonly IPositionRepository _positionRepository;
            private readonly IMapper _mapper;

            public DeletePositionCommandHandler(IPositionRepository positionRepository, IMapper mapper)
            {
                _positionRepository = positionRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
            {
                var position = await _positionRepository.GetAsync(request.Id);

                await _positionRepository.DeleteAsync(position);

                return Unit.Value;
            }
        }
    }

