using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Locations.Requests.Commands
{
    public class DeleteLocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
