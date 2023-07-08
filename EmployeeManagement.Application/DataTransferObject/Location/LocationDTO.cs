using EmployeeManagement.Application.DataTransferObject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.Location
{
    public class LocationDTO : BaseDTO, ILocationDTO
    {
        public string Town { get; set; }
        public string Street { get; set; }
    }
}
