using AutoMapper;
using EmployeeManagement.Application.CQRS.Locations.Requests.Commands;
using EmployeeManagement.Application.DataTransferObject.Location.Validators;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Application.Responses;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Locations.Handlers.Commands
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, BaseCommandResponse>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLocationDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LocationDTO);

            if (validationResult.IsValid == false) 
            {
                response.Success = false;
                response.Message = "Creating Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var location = _mapper.Map<Location>(request.LocationDTO);

                location = await _locationRepository.AddAsync(location);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = location.Id;
            }
            return response;
        }
    }
}
