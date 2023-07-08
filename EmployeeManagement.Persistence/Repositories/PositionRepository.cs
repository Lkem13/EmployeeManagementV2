using EmployeeManagement.Application.Persistence.Repository;
using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        private readonly EmployeeManagementDbContext _dbContext;
        public PositionRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;

        }
    }
}
