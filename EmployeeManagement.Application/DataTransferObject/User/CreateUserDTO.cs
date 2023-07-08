using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.DataTransferObject.Position;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.User
{
    public class CreateUserDTO : IUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }
        public int LocationId { get; set; }
    }
}
