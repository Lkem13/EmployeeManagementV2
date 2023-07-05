using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Persistence.Repository
{
    public interface IPositionRepository : IGenericRepository<Position>
    {
        Task<Position> GetPosition(int id);
    }
}
