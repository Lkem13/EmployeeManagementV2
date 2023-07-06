using EmployeeManagement.Application.DataTransferObject.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Users.Requests.Queries
{
    public class GetUserDetailRequest : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
}
