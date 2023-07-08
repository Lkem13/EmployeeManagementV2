using EmployeeManagement.Application.Persistence.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.User.Validators
{
    public class IUserDTOValidator : AbstractValidator<IUserDTO>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IPositionRepository _positionRepository;

        public IUserDTOValidator(ILocationRepository locationRepository, IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
            _locationRepository = locationRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Surname)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PositionId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var positionExists = await _positionRepository.Exists(id);
                        return !positionExists;
                    })
                    .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.LocationId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var locationExists = await _locationRepository.Exists(id);
                        return !locationExists;
                    })
                    .WithMessage("{PropertyName} does not exist.");
        }
    }
}
