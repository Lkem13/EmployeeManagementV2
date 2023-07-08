﻿using EmployeeManagement.Application.Persistence.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.User.Validators
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly ILocationRepository _locationRepository;
        public CreateUserDTOValidator(ILocationRepository locationRepository, IPositionRepository positionRepository) 
        {
            _positionRepository = positionRepository;
            _locationRepository = locationRepository;

            Include(new IUserDTOValidator(_locationRepository, _positionRepository));
        }
    }
}
