using EmployeeManagement.Application.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Positions.Requests.Commands
{
    public class CreatePositionCommand : IRequest<int>
    {
        public PositionDTO PositionDTO { get; set; }
    }
}
 