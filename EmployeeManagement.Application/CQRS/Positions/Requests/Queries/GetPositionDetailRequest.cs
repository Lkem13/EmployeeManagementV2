using EmployeeManagement.Application.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Positions.Requests.Queries
{
    public class GetPositionDetailRequest : IRequest<PositionDTO>
    {
        public string Name { get; set; }
    }
}
