using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence
{
    public class EmployeeManagementDbContextFactory : IDesignTimeDbContextFactory<EmployeeManagementDbContext>
    {
        public EmployeeManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EmployeeManagementDbContext>();
            var connectionString = configuration.GetConnectionString("EmployeeManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new EmployeeManagementDbContext(builder.Options);
        }
    }
}
