using EmployeeManagement.Application.DataTransferObject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject
{
    public class PositionDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
