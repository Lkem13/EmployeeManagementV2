using EmployeeManagement.MVC.Models;
using EmployeeManagement.MVC.Services.Base;

namespace EmployeeManagement.MVC.Contracts
{
    public interface ILocationService
    {
        Task<List<LocationVM>> GetLocations();
        Task<LocationVM> GetLocationDetails(int id);
        Task<Response<int>> CreateLocation(CreateLocationVM location);
        Task <Response<int>> UpdateLocation(int id, LocationVM location);
        Task <Response<int>> DeleteLocation(int id);
    }
}
