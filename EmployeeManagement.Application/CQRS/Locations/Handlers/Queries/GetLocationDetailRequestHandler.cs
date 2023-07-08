using AutoMapper;
using EmployeeManagement.Application.CQRS.Locations.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Locations.Handlers.Queries
{
    public class GetLocationDetailRequestHandler : IRequestHandler<GetLocationDetailRequest, LocationDTO>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetLocationDetailRequestHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<LocationDTO> Handle(GetLocationDetailRequest request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetAsync(request.Id);
            return _mapper.Map<LocationDTO>(location);
        }
    }
}
