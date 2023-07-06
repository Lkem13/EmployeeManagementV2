using EmployeeManagement.Application.DataTransferObject.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Locations.Requests.Queries
{
    public class GetLocationListRequest : IRequest<List<LocationDTO>>
    {

    }
}
