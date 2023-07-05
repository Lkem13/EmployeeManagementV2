using EmployeeManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Domain
{
    public class Location : BaseDomainEntity
    {
        public string Town { get; set; }
        public string Street { get; set; }
    }
}
