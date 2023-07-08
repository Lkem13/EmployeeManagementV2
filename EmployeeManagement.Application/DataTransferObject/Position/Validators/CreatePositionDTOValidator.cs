using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.Position.Validators
{
    public class CreatePositionDTOValidator : AbstractValidator<CreatePositionDTO>
    {
        public CreatePositionDTOValidator() 
        {
            Include(new IPositionDTOValidator());
        }
    }
}
