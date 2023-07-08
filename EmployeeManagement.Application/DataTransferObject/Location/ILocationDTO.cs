using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject.Location
{
    public interface ILocationDTO
    {
        public string Town { get; set; }
        public string Street { get; set; }
    }
}
