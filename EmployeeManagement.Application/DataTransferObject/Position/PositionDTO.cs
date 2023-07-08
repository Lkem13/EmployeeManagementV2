using EmployeeManagement.Application.DataTransferObject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.Position
{
    public class PositionDTO : BaseDTO, IPositionDTO
    {
        public string Name { get; set; }
    }
}
