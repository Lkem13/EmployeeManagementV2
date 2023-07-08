using AutoMapper;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EmployeeManagement.Application.CQRS.Locations.Requests.Commands;

namespace EmployeeManagement.Application.CQRS.Locations.Handlers.Commands
{
        public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
        {
            private readonly ILocationRepository _locationRepository;
            private readonly IMapper _mapper;

            public DeleteLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
            {
                _locationRepository = locationRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
            {
                var location = await _locationRepository.GetAsync(request.Id);

                await _locationRepository.DeleteAsync(location);

                return Unit.Value;
            }
        }
    }

