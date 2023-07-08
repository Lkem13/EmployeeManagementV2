using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Application.DataTransferObject.Position;
using EmployeeManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Positions.Requests.Commands
{
    public class CreatePositionCommand : IRequest<BaseCommandResponse>
    {
        public CreatePositionDTO PositionDTO { get; set; }
    }
}
 