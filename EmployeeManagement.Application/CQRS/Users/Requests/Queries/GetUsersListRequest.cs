using EmployeeManagement.Application.DataTransferObject.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Users.Requests.Queries
{
    public class GetUserListRequest : IRequest<List<UserListDTO>>
    {
    }
}
