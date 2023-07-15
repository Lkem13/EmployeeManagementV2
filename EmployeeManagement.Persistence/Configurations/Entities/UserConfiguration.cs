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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Roman",
                    Surname = "Romanowicz",
                    PositionId = 1,
                    LocationId = 1,
                },
                new User
                {
                    Id = 2,
                    Name = "Marcin",
                    Surname = "Gujer",
                    PositionId = 2,
                    LocationId = 1,
                },
                new User
                {
                    Id = 3,
                    Name = "Pawel",
                    Surname = "Bak",
                    PositionId = 3,
                    LocationId = 3,
                });
        }
    }
}
