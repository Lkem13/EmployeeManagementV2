using EmployeeManagement.Application.DataTransferObject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject
{
    public class LocationDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
    }
}
