using EmployeeManagement.Application.DataTransferObject.Position;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Positions.Requests.Commands
{
    public class UpdatePositionCommand : IRequest<Unit>
    {
        public PositionDTO PositionDTO { get; set; }
    }
}
