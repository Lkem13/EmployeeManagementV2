using EmployeeManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Configurations.Entities
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasData(
                new Position
                {
                    Id = 1,
                    Name = "IT Support"
                },
                new Position
                {
                    Id = 2,
                    Name = "HR",
                },
                new Position
                {
                    Id = 3,
                    Name = "Financial",
                });
        }
    }
}
