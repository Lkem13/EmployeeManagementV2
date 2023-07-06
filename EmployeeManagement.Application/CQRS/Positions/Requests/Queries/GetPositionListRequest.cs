using EmployeeManagement.Application.DataTransferObject.Position;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Positions.Requests.Queries
{
    public class GetPositionListRequest : IRequest<List<PositionDTO>>
    {
    }
}
