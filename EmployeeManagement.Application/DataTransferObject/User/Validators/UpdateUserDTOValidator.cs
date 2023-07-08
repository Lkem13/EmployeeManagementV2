using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.User.Validators
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IPositionRepository _positionRepository;

        public UpdateUserDTOValidator(ILocationRepository locationRepository, IPositionRepository positionRepository)
        {
            _locationRepository = locationRepository;
            _positionRepository = positionRepository;

            Include(new IUserDTOValidator(_locationRepository, _positionRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }   
    }
}
