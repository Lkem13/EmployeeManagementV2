using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeManagementDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("EmployeeManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
