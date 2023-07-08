using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.Location.Validators
{
    public class UpdateLocationDTOValidator : AbstractValidator<LocationDTO>
    {
        public UpdateLocationDTOValidator() 
        {
            Include(new ILocationDTOValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
