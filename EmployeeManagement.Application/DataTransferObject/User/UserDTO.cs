using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Application.DataTransferObject.Common;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.DataTransferObject.Position;

namespace EmployeeManagement.Application.DataTransferObject.User
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public PositionDTO Position { get; set; }
        public int PositionId { get; set; }
        public LocationDTO Location { get; set; }
        public int LocationId { get; set; }
    }
}
