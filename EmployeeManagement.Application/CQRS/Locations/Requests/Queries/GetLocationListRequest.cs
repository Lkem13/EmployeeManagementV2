using EmployeeManagement.Application.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Locations.Requests
{
    public class GetLocationListRequest : IRequest<List<LocationDTO>>
    {

    }
}
