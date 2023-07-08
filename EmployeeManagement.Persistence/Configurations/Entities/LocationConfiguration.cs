using EmployeeManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Configurations.Entities
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location
                {
                    Id = 1,
                    Town = "Krakow",
                    Street = "Stawska 13"
                },
                new Location
                {
                    Id = 2,
                    Town = "Krakow",
                    Street = "Milska 10"
                },
                new Location
                {
                    Id = 3,
                    Town = "Katowice",
                    Street = "Cielska 5"
                });
        }
    }
}
