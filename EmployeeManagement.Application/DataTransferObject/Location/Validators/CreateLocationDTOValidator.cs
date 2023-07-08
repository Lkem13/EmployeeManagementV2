using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.Location.Validators
{
    public class CreateLocationDTOValidator : AbstractValidator<CreateLocationDTO>
    {
        public CreateLocationDTOValidator() 
        {
            Include(new ILocationDTOValidator());
        }
    }
}
