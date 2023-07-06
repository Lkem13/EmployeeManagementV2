using EmployeeManagement.Application.DataTransferObject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.User
{
    public class UpdateUserDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }
        public int LocationId { get; set; }
    }
}
