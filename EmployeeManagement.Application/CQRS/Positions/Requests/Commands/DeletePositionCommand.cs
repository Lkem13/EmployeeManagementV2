using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Positions.Requests.Commands
{
    public class DeletePositionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
