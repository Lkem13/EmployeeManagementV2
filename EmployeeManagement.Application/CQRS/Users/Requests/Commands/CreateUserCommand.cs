using EmployeeManagement.Application.DataTransferObject.User;
using EmployeeManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.CQRS.Users.Requests.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDTO UserDTO { get; set; }
    }
}
