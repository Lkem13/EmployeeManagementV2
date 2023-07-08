using EmployeeManagement.Application.Persistence.Repository;
using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        private readonly EmployeeManagementDbContext _dbContext;
        public LocationRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;

        }
    }
}
