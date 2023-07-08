using AutoMapper;
using EmployeeManagement.Application.CQRS.Locations.Requests.Commands;
using EmployeeManagement.Application.CQRS.Positions.Handlers.Commands;
using EmployeeManagement.Application.DataTransferObject.Location.Validators;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Locations.Handlers.Commands
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Unit>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLocationDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LocationDTO);

            if (validationResult.IsValid == false)
            {
                throw new Exception();
            }

            var location = await _locationRepository.GetAsync(request.LocationDTO.Id);

            _mapper.Map(request.LocationDTO, location);

            await _locationRepository.UpdateAsync(location);

            return Unit.Value;
        }
    }
}
