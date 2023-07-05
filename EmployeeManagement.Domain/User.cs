﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position Position { get; set; }
        public string PositionId { get; set; }
        public Location Location { get; set; }
        public string LocationId { get; set; }
    }
}
