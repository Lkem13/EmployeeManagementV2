using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.Position.Validators
{
    public class UpdatePositionDTOValidator : AbstractValidator<PositionDTO>
    {
        public UpdatePositionDTOValidator() 
        {
            Include(new IPositionDTOValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
