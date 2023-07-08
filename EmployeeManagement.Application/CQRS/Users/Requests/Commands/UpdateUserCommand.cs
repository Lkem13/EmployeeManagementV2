using EmployeeManagement.Application.DataTransferObject.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Users.Requests.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateUserDTO UserDTO { get; set; }
    }
}
