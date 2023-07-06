using EmployeeManagement.Application.DataTransferObject.Common;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.DataTransferObject.Position;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.User
{
    public class UserListDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public PositionDTO Position { get; set; }
        public LocationDTO Location { get; set; }
    }
}
