using EmployeeManagement.Application.DataTransferObject.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Locations.Requests.Commands
{
    public class UpdateLocationCommand : IRequest<Unit>
    {
        public LocationDTO LocationDTO { get; set; }

    }
}
