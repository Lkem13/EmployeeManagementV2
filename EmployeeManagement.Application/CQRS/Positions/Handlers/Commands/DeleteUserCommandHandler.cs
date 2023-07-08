using AutoMapper;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Domain;

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

                if (position == null)
                {
                    throw new NotFoundException(nameof(Position), request.Id);
                }

                await _positionRepository.DeleteAsync(position);

                return Unit.Value;
            }
        }
    }

