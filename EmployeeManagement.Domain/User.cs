using EmployeeManagement.Domain.Common;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Domain
{
    public class User : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
