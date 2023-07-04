using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DataTransferObject
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public PositionDTO Position { get; set; }
        public string PositionId { get; set; }
        public LocationDTO Location { get; set; }
        public string LocationId { get; set; }
    }
}
