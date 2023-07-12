using EmployeeManagement.MVC.Models;
using EmployeeManagement.MVC.Services.Base;

namespace EmployeeManagement.MVC.Contracts
{
    public interface IPositionService
    {
        Task<List<PositionVM>> GetPositions();
        Task<PositionVM> GetPositionDetails(int id);
        Task<Response<int>> CreatePosition(CreatePositionVM position);
        Task<Response<int>> UpdatePosition(int id, PositionVM position);
        Task<Response<int>> DeletePosition(int id);
    }
}
