using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
    }
}
