using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Application.DataTransferObject.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Locations.Requests.Commands
{
    public class CreateLocationCommand : IRequest<int>
    {
        public CreateLocationDTO LocationDTO { get; set; }
    }
}
 