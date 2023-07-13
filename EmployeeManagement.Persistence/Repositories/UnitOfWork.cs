using EmployeeManagement.Application.Constants;
using EmployeeManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementDbContext _context;
        private IUserRepository _userRepository;
        private ILocationRepository _locationRepository;
        private IPositionRepository _positionRepository;

        public UnitOfWork(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(_context);

        public ILocationRepository LocationRepository =>
            _locationRepository ??= new LocationRepository(_context);

        public IPositionRepository PositionRepository =>
            _positionRepository ??= new PositionRepository(_context);

        public void Dispose() 
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
