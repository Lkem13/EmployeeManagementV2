using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly EmployeeManagementDbContext _dbContext;
        public UserRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<List<User>> GetUsersWithDetails()
        {
            var users = await _dbContext.Users
                .Include(q => q.Position)
                .Include(p => p.Location)
                .ToListAsync();
            return users;
        }

        public async Task<User> GetUserWithDetails(int id)
        {
            var user = await _dbContext.Users
                .Include(q => q.Position)
                .Include(p => p.Location)
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
    }
}
