using EmployeeManagement.MVC.Models;
using EmployeeManagement.MVC.Services.Base;

namespace EmployeeManagement.MVC.Contracts
{
    public interface IUserService
    {
        Task<List<EmployeeVM>> GetEmployees();
        Task<EmployeeVM> GetEmployeeDetails(int id);
        Task<Response<int>> CreateEmployee(CreateEmployeeVM employee);
        Task<Response<int>> DeleteEmployee(int id);
        Task<AdminEmployeeViewVM> GetAdminUserList();
    }
}
