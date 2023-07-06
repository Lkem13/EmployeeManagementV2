using AutoMapper;
using EmployeeManagement.Application.CQRS.Locations.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Locations.Handlers.Queries
{
    public class GetLocationListRequestHandler : IRequestHandler<GetLocationListRequest, List<LocationDTO>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetLocationListRequestHandler(ILocationRepository locationRepository, IMapper mapper) 
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<List<LocationDTO>> Handle(GetLocationListRequest request, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetAllAsync();
            return _mapper.Map<List<LocationDTO>>(locations);
        }
    }
}
