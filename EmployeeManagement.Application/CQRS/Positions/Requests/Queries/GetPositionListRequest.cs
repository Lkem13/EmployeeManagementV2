using EmployeeManagement.Application.DataTransferObject;
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
