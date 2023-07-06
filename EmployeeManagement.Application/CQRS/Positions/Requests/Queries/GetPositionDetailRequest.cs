using EmployeeManagement.Application.DataTransferObject.Position;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Positions.Requests.Queries
{
    public class GetPositionDetailRequest : IRequest<PositionDTO>
    {
        public int Id{ get; set; }
    }
}
