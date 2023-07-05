using EmployeeManagement.Application.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Locations.Requests.Commands
{
    public class CreateLocationCommand : IRequest<int>
    {
        public LocationDTO LocationDTO { get; set; }
    }
}
 