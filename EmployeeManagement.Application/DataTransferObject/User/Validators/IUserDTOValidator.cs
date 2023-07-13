﻿using EmployeeManagement.Application.Contracts.Persistence;
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


        }
    }
}
