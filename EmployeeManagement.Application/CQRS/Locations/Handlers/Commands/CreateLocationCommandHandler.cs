using AutoMapper;
using EmployeeManagement.Application.CQRS.Locations.Requests.Commands;
using EmployeeManagement.Application.Persistence.Repository;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Locations.Handlers.Commands
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, int>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = _mapper.Map<Location>(request.LocationDTO);

            location = await _locationRepository.AddAsync(location);

            return location.Id;
        }
    }
}
