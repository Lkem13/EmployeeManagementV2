using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Locations.Requests.Commands
{
    public class CreateLocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLocationDTO LocationDTO { get; set; }
    }
}
 